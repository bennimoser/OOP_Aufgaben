using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationWPFExample
{
    public class MainViewModel
    {
        private string textBoxContent;
        public string TextBoxContent
        {
            get
            {
                return textBoxContent;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.ToUpper() == "HUND")
                {
                    textBoxContent = value;
                }
                else
                {
                    throw new Exception("Das ist kein Hund!!!!");
                }
            }
        }
    }
}
