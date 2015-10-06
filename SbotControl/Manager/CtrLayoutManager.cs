using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace SbotControl.Manager
{
    public class CtrLayoutManager
    {
        #region Vars
        public string _dataPath = string.Empty;
        List<Core.CtrLayout> _layoutList;
        #endregion
        #region Functions
        public CtrLayoutManager(string DataPath)
        {
            _dataPath = DataPath;
            LoadLayout();
            if (_layoutList == null)
            {
                _layoutList = new List<Core.CtrLayout>();
            }
        }
        private Core.CtrLayout AddLayout(string layoutName, int layoutVersion, byte[] layoutDefault)
        {
            Core.CtrLayout lay = new Core.CtrLayout(layoutName, layoutVersion, layoutDefault, layoutDefault);
            _layoutList.Add(lay);
            return lay;
        }
        public Core.CtrLayout GetLayout(string layoutName, int layoutVersion, byte[] layoutDefault)
        {
            foreach (Core.CtrLayout lay in _layoutList)
            {
                if (lay.LayoutName == layoutName)
                {
                    if (lay.LayoutVersion < layoutVersion)
                    {
                        lay.LayoutDefault = lay.LayoutUser = layoutDefault;
                        lay.LayoutVersion = layoutVersion;
                        SaveLayout();
                    }
                    return lay;
                }
            }
            Core.CtrLayout Newlay = AddLayout(layoutName, layoutVersion, layoutDefault);
            SaveLayout();
            return Newlay;
        }
        public bool SaveLayout()
        {
            try
            {
                SerializeObject<List<Core.CtrLayout>>(_layoutList, _dataPath);
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public bool LoadLayout()
        {
            try
            {
                _layoutList = DeSerializeObject<List<Core.CtrLayout>>(_dataPath);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        private void SerializeObject<T>(T serializableObject, string fileName)
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
                System.Windows.Forms.MessageBox.Show(ex.Message);
                //Log exception here
            }
        }
        /// <summary>
        /// Deserializes an xml file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private T DeSerializeObject<T>(string fileName)
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
        #endregion
    }
}
