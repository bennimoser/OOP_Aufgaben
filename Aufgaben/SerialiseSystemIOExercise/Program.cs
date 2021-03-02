using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerialiseSystemIOExercise
{
    class Program
    {
        public static void Main(string[] args)
        {

            #region XML Serializing
            Person person1 = new Person() { Firstname = "Benjamin", Lastname = "Moser", Birthday = new BirthDate() { Month = 11, Day = 11, Year = 2000 }, _sex = "Tomate" };
            Console.WriteLine("Before Serialize");
            person1.WriteInformation();
            
            XmlSerializer xml = new XmlSerializer(typeof(Person));

            FileStream stream = new FileStream("serialize.txt", FileMode.Create);

            xml.Serialize(stream, person1);
            stream.Close();
            Console.WriteLine("After Serialize");
            stream = new FileStream("serialize.txt", FileMode.Open);

            var personresult = (Person)xml.Deserialize(stream);
            personresult.WriteInformation();
            stream.Close();

            #endregion

            Console.WriteLine();

            #region Own Formatter

            MyFormatter formatter = new MyFormatter();
            stream = new FileStream("serializebinary.txt", FileMode.Create);
            formatter.Serialize(stream, person1);

            stream.Close();
            stream = new FileStream("serializebinary.txt", FileMode.Open);
            var binaryPerson = (Person)formatter.Deserialize(stream);

            #endregion
        }
    }

    [Serializable]
    public class Person
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public BirthDate Birthday { get; set; }

        [XmlIgnore]
        [NonSerialized]
        public string _sex;


        public void WriteInformation()
        {
            Console.WriteLine("Firstname: " + Firstname);
            Console.WriteLine("Lastname : " + Lastname);
            Console.WriteLine("Day of Birth: {0}.{1}.{2}", Birthday.Day, Birthday.Month, Birthday.Year);
        }
    }

    [Serializable]
    public class BirthDate
    {
        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }
    }

    public class MyFormatter : IFormatter
    {
        public ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public StreamingContext Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object Deserialize(Stream serializationStream)
        {
            Console.WriteLine("Formatter is now Deserializing");
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(serializationStream);
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            Console.WriteLine("Formatter is now Serializing");
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(serializationStream, graph);
        }
    }
}
