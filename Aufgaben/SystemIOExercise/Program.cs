using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SystemIOExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            #region DriveInformation

            DriveInfo[] driveinfos = DriveInfo.GetDrives();
            foreach(DriveInfo driveinfo in driveinfos)
            {
                Console.WriteLine(driveinfo.Name);
                Console.WriteLine(driveinfo.TotalFreeSpace / 1024 * 1024);
                Console.WriteLine(driveinfo.DriveFormat);
                Console.WriteLine(driveinfo.TotalSize / 1024 * 1024);
                Console.WriteLine(driveinfo.DriveType.ToString());
                Console.WriteLine("-----------------");
            }

            #endregion
            #region Path, Directory, File

            if (!Directory.Exists("C:/Temp"))
            {
                Directory.CreateDirectory("C:/Temp");
            }

            DirectoryInfo info = Directory.CreateDirectory("C:/Temp/TestOrdner");
            info.Attributes = FileAttributes.Hidden | FileAttributes.ReadOnly;
            Directory.SetCreationTime("C:/Temp/TestOrdner", new DateTime(2000, 11, 11, 7, 45, 00));

            if (!File.Exists("C:/Temp/test.txt"))
            {
                File.Create("C:/Temp/test.txt");
            }

            List<string> files = Directory.GetFiles("C:/Temp", "*.txt", SearchOption.AllDirectories).ToList();

            foreach(var file in files)
            {
                var fullpath = Path.GetFileNameWithoutExtension(file);
            }

            #endregion

            #region File System Watcher

            FileSystemWatcher watcher = new FileSystemWatcher("C:/Temp/TestOrdner");
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
            watcher.Changed += Watcher_Changed;
            watcher.Created += Watcher_Changed;
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size;
            #endregion

            #region MessageType
            MessageType1 messageType = new MessageType1();
            messageType.Id = 1;
            messageType.message = "Hallo";
            FileStream stream = new FileStream("iwas.txt", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, messageType);
            stream.Close();

            stream = new FileStream("iwas.txt", FileMode.OpenOrCreate, FileAccess.Read);
            var irgendeinobject = (IMessageType)formatter.Deserialize(stream);
            #endregion

        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.FullPath);
        }
    }

    public interface IMessageType
    {
        string message { get; set; }
        
        int Id { get; set; }

    }

    [Serializable]
    public class MessageType1 : IMessageType
    {
        public string message { get; set; }
        public int Id { get; set; }

        public void SomeMethod()
        {

        }
    }

    [Serializable]
    public class MessageType2 : IMessageType
    {
        public string message { get; set; }
        public int Id { get; set; }

        public int Zahl { get; set; }
    }
}
