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
            Person person1 = new Person() { Firstname = "Benjamin", Lastname = "Moser", Birthday = DateTime.Now, _sex = "Tomate" };
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

            #region With Surrogate

            using (FileStream fs = new FileStream("data.dat", FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
            {
                SurrogateSelector ss = new SurrogateSelector();
                ss.AddSurrogate(typeof(Person), new StreamingContext(StreamingContextStates.All), new PersonSurrogate());

                IFormatter binaryformatter = new BinaryFormatter();
                binaryformatter.SurrogateSelector = ss;

                binaryformatter.Serialize(fs, person1);

                fs.Seek(0, SeekOrigin.Begin);
                Person person2 = (Person)binaryformatter.Deserialize(fs);

                fs.Close();
            }
            #endregion
        }
    }

    [Serializable]
    public class Person
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime Birthday { get; set; }

        [XmlIgnore]
        [NonSerialized]
        public string _sex;


        public void WriteInformation()
        {
            Console.WriteLine("Firstname: " + Firstname);
            Console.WriteLine("Lastname : " + Lastname);
            Console.WriteLine("Day of Birth: {0}.{1}.{2}", Birthday.Day, Birthday.Month, Birthday.Year);
        }


        //Gehören in die serialisierte Klasse
        [OnSerializing()]
        internal void OnSerializing(StreamingContext context)
        {
            Console.WriteLine("Now it will be serialized!");
        }

        [OnSerialized()]
        internal void OnSerialized(StreamingContext context)
        {
            Console.WriteLine("Now it has been serialized");
        }

        [OnDeserializing()]
        internal void OnDeserializing(StreamingContext context)
        {
            Console.WriteLine("It will now be deserialized");
        }

        [OnDeserialized()]
        internal void OnDeserialized(StreamingContext context)
        {
            Console.WriteLine("Now it has been deserialized");
        }
    }

    public class MyFormatter : IFormatter
    {
        public MyFormatter()
        {
            this.Context = new StreamingContext(StreamingContextStates.All);
        }

        public ISurrogateSelector SurrogateSelector { get; set; }
        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }

        public object Deserialize(Stream serializationStream)
        {
            Console.WriteLine("Message from Formatter : Formatter is now Deserializing");
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(serializationStream);
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            Console.WriteLine("Message from Formatter : Formatter is now Serializing");
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(serializationStream, graph);
        }
    }

    public class PersonSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            Person person = (Person)obj;
            info.AddValue("Firstname", person.Firstname);
            info.AddValue("Lastname", person.Lastname);
            info.AddValue("Birthday", person.Birthday);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            Person person = (Person)obj;
            person.Firstname = info.GetString("Firstname");
            person.Lastname = info.GetString("Lastname");
            person.Birthday = info.GetDateTime("Birthday");
            return person;
        }
    }
}
