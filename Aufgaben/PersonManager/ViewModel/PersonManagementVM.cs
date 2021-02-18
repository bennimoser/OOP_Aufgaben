using Microsoft.SqlServer.Server;
using PersonManager.Commands;
using PersonManager.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace PersonManager.ViewModel
{
    public class PersonManagementVM
    {
        public PersonManagementVM()
        {
            this.Person = new PersonVM();
            this.SettingArgs = new SettingArgsVM();
        }

        public PersonVM Person { get; set; }

        public SettingArgsVM SettingArgs { get; set; }

        public ICommand SetFormatterCommand
        {
            get
            {
                return new Command((obj) =>
                {
                    string str = obj as string;

                    switch (str)
                    {
                        case "XML":
                            this.SettingArgs.Serializer = Serializers.XmlSerializer;
                            break;
                        case ".NET":
                            this.SettingArgs.Serializer = Serializers.BinarayFormatter;
                            break;
                        default:
                            throw new ArgumentException("Invalid Serializer");       
                    }
                });
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return new Command((obj) =>
                {
                    // TODO Test file path on valid.

                    using (FileStream fs = new FileStream(this.SettingArgs.FilePath, FileMode.Open, FileAccess.Write))
                    {
                        SurrogateSelector ss = new SurrogateSelector();
                        ss.AddSurrogate(typeof(Person), new StreamingContext(StreamingContextStates.All),
                                                        new PersonSerializationSurrogate());

                        Person p = new Person()
                        {
                            FirstName = this.Person.FirstName,
                            LastName = this.Person.LastName,
                            Birthday = this.Person.Birthday,
                            Height = this.Person.Height,
                        };

                        switch (this.SettingArgs.Serializer)
                        {
                            case Serializers.XmlSerializer:
                                {
                                    XmlSerializer serializer = new XmlSerializer(typeof(Person));
                                    serializer.Serialize(fs, p);
                                    break;
                                }
                            case Serializers.BinarayFormatter:
                                {
                                    IFormatter serializer = new BinaryFormatter();
                                    serializer.SurrogateSelector = ss;
                                    serializer.Serialize(fs, p);
                                    break;
                                }
                        }
                    }
                },

                (obj2) => !String.IsNullOrWhiteSpace(this.SettingArgs.FilePath));
            }
        }

        public ICommand LoadCommand
        {
            get
            {
                return new Command((obj) =>
                {
                    using (FileStream fs = new FileStream(this.SettingArgs.FilePath, FileMode.Open, FileAccess.Read))
                    {
                        SurrogateSelector ss = new SurrogateSelector();
                        ss.AddSurrogate(typeof(Person), new StreamingContext(StreamingContextStates.All),
                                                        new PersonSerializationSurrogate());

                        try
                        {
                            Person p = null;

                            switch (this.SettingArgs.Serializer)
                            {
                                case Serializers.XmlSerializer:
                                    {
                                        XmlSerializer serializer = new XmlSerializer(typeof(Person));
                                        fs.Seek(0, SeekOrigin.Begin);
                                        p = (Person)serializer.Deserialize(fs);
                                        break;
                                    }
                                case Serializers.BinarayFormatter:
                                    {
                                        IFormatter serializer = new BinaryFormatter();
                                        serializer.SurrogateSelector = ss;
                                        fs.Seek(0, SeekOrigin.Begin);
                                        p = (Person)serializer.Deserialize(fs);
                                        break;
                                    }
                            }

                            this.Person.FirstName = p.FirstName;
                            this.Person.LastName = p.LastName;
                            this.Person.Birthday = p.Birthday;
                            this.Person.Height = p.Height;
                        }
                        catch
                        {
                            throw new Exception("Invalid File Format.");
                        }
                    }
                },

                (obj2) => !String.IsNullOrWhiteSpace(this.SettingArgs.FilePath));
            }
        }
    }
}