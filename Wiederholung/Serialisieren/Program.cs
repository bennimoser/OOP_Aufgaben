using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialisieren
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Person person = new Person { Address = "aisndasd", Birthday = DateTime.Now, Firstname = "Benjamin", Lastname = "Moser" };
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream("C:/Temp/Serialisetext.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            formatter.Serialize(stream, person);
            stream.Seek(0,SeekOrigin.Begin);

            var deserializedperson = (Person)formatter.Deserialize(stream);


            FileStream xmlStream = new FileStream("C:/Temp/Serialisetext.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xmlformatter = new XmlSerializer(person.GetType());
            xmlformatter.Serialize(xmlStream, person);
            xmlStream.Seek(0, SeekOrigin.Begin);
            var xmldesirializedperson = (Person)xmlformatter.Deserialize(xmlStream);
        }
    }

    [Serializable]
    public class Person
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime Birthday { get; set; }
        
        public string Address { get; set; }

        [OnSerializing]
        public void OnSerializing(StreamingContext context)
        {
            Console.WriteLine("This is getting serialized now");
        }

        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
            Console.WriteLine("This was deserialized now");
        }

        [OnSerialized]
        public void OnSerialized(StreamingContext context)
        {
            Console.WriteLine("This was serialized now");
        }

        [OnDeserializing]
        public void OnDeserializing(StreamingContext context)
        {
            Console.WriteLine("This is deserializing now");
        }
    }
}
