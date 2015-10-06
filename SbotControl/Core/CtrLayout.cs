using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SbotControl.Core
{
    [Serializable]
    public class CtrLayout
    {

        #region Properties
        private string _layoutName;
        public string LayoutName
        {
            get { return _layoutName; }
            set { _layoutName = value; }
        }
        private int _layoutVersion;
        public int LayoutVersion
        {
            get { return _layoutVersion; }
            set { _layoutVersion = value; }
        }
        private byte[] _layoutDefault;
        public byte[] LayoutDefault
        {
            get { return _layoutDefault; }
            set { _layoutDefault = value; }
        }
        private byte[] _layoutUser;
        public byte[] LayoutUser
        {
            get { return _layoutUser; }
            set { _layoutUser = value; }
        }

        #endregion
        #region Functions
        public CtrLayout()
        {
        }
        public CtrLayout(string layoutName, int layoutVersion, byte[] layoutDefault, byte[] layoutUser)
        {
            _layoutName = layoutName;
            _layoutVersion = layoutVersion;
            _layoutDefault = layoutDefault;
            _layoutUser = layoutUser;
        }
        #endregion

    }
}
