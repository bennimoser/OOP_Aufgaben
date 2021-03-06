using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SystemIO
{
    class Program
    {
        public static void Main(string[] args)
        {
            #region Stream

            FileStream writeStream = new FileStream("exercise.txt", FileMode.OpenOrCreate, FileAccess.Write);

            string message = "Message for the text file";
            byte[] bytearray = Encoding.UTF8.GetBytes(message);
            writeStream.Write(bytearray, 0, bytearray.Length);

            writeStream.Close();

            FileStream readStream = new FileStream("exercise.txt", FileMode.Open, FileAccess.Read);
            bytearray = new byte[1024];
            int readbytes = readStream.Read(bytearray, 0, bytearray.Length);
            byte[] copyarray = new byte[readbytes];
            Array.Copy(bytearray, copyarray, readbytes);
            Console.WriteLine(Encoding.UTF8.GetString(copyarray));

            readStream.Close();

            #endregion

            #region StreamWriter/Reader

            FileStream stream = new FileStream("streamexercise.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using(StreamReader reader = new StreamReader(stream))
            using(StreamWriter writer = new StreamWriter(stream))
            {
                message = "Message from a Streamwriter";
                writer.WriteLine(message);


                stream.Seek(0, SeekOrigin.Begin);

                string endresult = reader.ReadLine();
                Console.WriteLine(endresult);
            }

            #endregion

            #region Path, Directory, File

            if (!Directory.Exists("C:/Temp/TestA"))
            {
                Directory.CreateDirectory("C:/Temp/TestA");
            }

            File.Create("C:/Temp/TestA/one.txt").Close();
            File.Create("C:/Temp/TestA/two.txt").Close();
            File.Create("C:/Temp/TestA/three.txt").Close();

            if (!Directory.Exists("C:/Temp/TestB"))
            {
                Directory.Move("C:/Temp/TestA", "C:/Temp/TestB");
            }
            else
            {
                Directory.Delete("C:/Temp/TestB", true);
                Directory.Move("C:/Temp/TestA", "C:/Temp/TestB");
            }

            Directory.SetCreationTime("C:/Temp/TestB", new DateTime(1910, 1, 1, 12, 10, 14));

            string extension = Path.GetExtension("C:/Temp/TestA/one.txt");
            Console.WriteLine("Extension : " + extension);
            string fullname = Path.GetFileName("C:/Temp/TestA/one.txt");
            Console.WriteLine("Fullname : " + fullname);
            string filename = Path.GetFileNameWithoutExtension("C:/Temp/TestA/one.txt");
            Console.WriteLine("Filename : " + filename);

            #endregion

        }
    }
}
