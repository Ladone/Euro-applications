using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Issu.Libs
{
    class StringMultiLanguage
    {
        private string _valueUA;
        private string _valueEN;

        public StringMultiLanguage()
        {
            this._valueUA = null;
            this._valueEN = null;
        }

        public StringMultiLanguage(string valueUA, string valueEN)
        {
            this._valueUA = valueUA;
            this._valueEN = valueEN;
        }

        public string UA
        {
            get { return _valueUA; }
            set { _valueUA = value; }
        }

        public string EN
        {
            get { return _valueEN; }
            set { _valueEN = value; }
        }
    }
}
