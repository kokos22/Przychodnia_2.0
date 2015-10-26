using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    class WhereParams
    {
        private string _name;
        private string _valueString;
        private int _valueInt = 0;

        public WhereParams(string iName, int iValue)
        {
            _name = iName;
            _valueInt = iValue;
        }

        public WhereParams(string iName, string iValue)
        {
            _name = iName;
            _valueString = iValue;
        }


        public void SetParams(string iName, int iValue)
        {
            _name = iName;
            _valueInt = iValue;
        }

        public void SetParams(string iName, string iValue)
        {
            _name = iName;
            _valueString = iValue;
        }

        public string GetParams()
        {
            if (_valueInt == 0 && _valueString == "")
                return "";
            else if (_valueInt != 0)
                return " " + _name + " = " + _valueInt;
            else 
                return " " + _name + " = '" + _valueString + "'";
        }
    }
}
