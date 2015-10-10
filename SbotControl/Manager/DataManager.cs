using System;
using System.Collections.Generic;

using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Data;

namespace SbotControl
{
    public class DataManager
    {
        public static string DataPath { get { return Application.StartupPath + "\\Data.xml" ;} }
        public static string LayoutDataPath { get { return Application.StartupPath + "\\LayoutData"; } }
        public static string ServerListPath { get { return Application.StartupPath + "\\ServersList.txt"; } }
        public List<Account> Accounts = new List<Account>();
        public static Dictionary<string, string> ServerList = new Dictionary<string, string>();
        public enum ChangesType
        {
            Added,
            Deleted,
            ActiveTrue,
            ActiveFalse,
        }
        public delegate void AccountListChangedEventhandler(Account sender, ChangesType e);
        public event AccountListChangedEventhandler AccountListChanged;
        private static Datasource.dsDataTableAdapters.ExceptionTableAdapter adpEx = new Datasource.dsDataTableAdapters.ExceptionTableAdapter();

        public bool SaveSettings()
        {
            try
            {
                Properties.Settings.Default.Save();
                Program.AddRemoveStartup(Properties.Settings.Default.RunAtStartup);
                SerializeObject<List<Account>>(Accounts, DataPath);
                return true;
            }
            catch (Exception ex)
            {
                Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace);
                return false;
            }
        }
        public void LoadSettings()
        {
            try
            {
                Accounts = DeSerializeObject<List<Account>>(DataPath);
                if (Accounts == null)
                    Accounts = new List<Account>();
                foreach (Account item in Accounts)
                    item.PropertyChanged += Account_PropertyChanged;
            }
            catch (Exception ex)
            {
                Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace);
                Accounts = new List<Account>();
            }
        }
        public void LoadServerList()
        {
            ServerList = new Dictionary<string, string>();
            StreamReader sr = new StreamReader(ServerListPath);
            try
            {
                while (!sr.EndOfStream)
                {
                    string serverLine = sr.ReadLine();
                    ServerList.Add(serverLine.Split(Convert.ToChar(";"))[0], serverLine.Split(Convert.ToChar(";"))[1]);
                }
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
            finally
            {
                sr.Close();
            }
        }

        public void AddAccount(Account account)
        {
            try
            {
                Accounts.Add(account);
                account.PropertyChanged += Account_PropertyChanged;
                if (AccountListChanged != null)
                    AccountListChanged(account, ChangesType.Added);
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        private void Account_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName != "Start")
                    return;
                if (AccountListChanged != null)
                {
                    if (((Account)sender).Start)
                        AccountListChanged((Account)sender, ChangesType.ActiveTrue);
                    else
                        AccountListChanged((Account)sender, ChangesType.ActiveFalse);
                }
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        public void RemoveAccount(Account account)
        {
            try
            {
                Accounts.Remove(account);
                if (AccountListChanged != null)
                    AccountListChanged(account, ChangesType.Deleted);
            }
            catch (Exception ex)
            { Program.dbOperations.SaveToEx(this.GetType().ToString(), ex.Message, ex.StackTrace); }
        }
        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }
        /// <summary>
        /// Deserializes an xml file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                string attributeXml = string.Empty;

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }

            return objectOut;
        }
        //Replaced with db.SaveToEx
        //public static void AddEx(Exception ex, string ClassType)
        //{
        //    adpEx.Insert(DateTime.Now, ClassType, ex.Message, ex.StackTrace);
        //}

    }
}
