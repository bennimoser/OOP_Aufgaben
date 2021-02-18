using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PersonManager.Model
{
    public class SettingArgs
    {
        public string FilePath { get; set; }

        public Serializers Serializer { get; set; }
    }
}
