using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.FullPath);
        }
    }
}
