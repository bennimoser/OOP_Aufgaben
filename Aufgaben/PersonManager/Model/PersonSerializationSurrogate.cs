using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.Model
{
    public class PersonSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", ((Person)obj).FirstName);
            info.AddValue("LastName", ((Person)obj).LastName);
            info.AddValue("Birthday", ((Person)obj).Birthday);
            info.AddValue("Height", ((Person)obj).Height);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            Person p = (Person)obj;
            p.FirstName = info.GetString("FirstName");
            p.LastName = info.GetString("LastName");
            p.Birthday = info.GetDateTime("Birthday");
            p.Height = info.GetInt32("Height");
            return p;
        }
    }
}
