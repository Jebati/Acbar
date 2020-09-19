using System;
using System.Collections.Generic;
using System.IO;

namespace Acbar
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine(new string('-', 32));

                Console.WriteLine($"Name: {drive.Name}");
                Console.WriteLine($"Drive type: {drive.DriveType}");
                Console.WriteLine($"Fyle system: {drive.DriveFormat}");

                if (drive.IsReady)
                {
                    PrintDriverSpace("Disk volume", drive.TotalSize);
                    PrintDriverSpace("Headspace", drive.TotalFreeSpace);

                    Console.WriteLine($"Label: {drive.VolumeLabel}");

                    string[] directories = Directory.GetDirectories(drive.Name);
                    string[] files = Directory.GetFiles(drive.Name);

                    Console.WriteLine("Root:");

                    PrintStringsArray(directories, "", "\\");
                    PrintStringsArray(files);

                }

                Console.WriteLine(new string('-', 32));
                Console.WriteLine();
            }
        }

        class ByteConverter
        {
            public static double BytesToGigabytes(long bytes)
            {
                return (double)bytes / 1073741824;
            }

            public static double BytesToMegabytes(long bytes)
            {
                return (double)bytes / 1048576;
            }

            public static double BytesToKilobytes(long bytes)
            {
                return (double)bytes / 1024;
            }
        }

        static void PrintDriverSpace(string label, long bytes)
        {
            Console.Write($"{label}: ");
            if (bytes >= 1073741824)
            {
                Console.WriteLine($"{ByteConverter.BytesToGigabytes(bytes)} GB");
            }
            else if (bytes >= 1048576)
            {
                Console.WriteLine($"{ByteConverter.BytesToMegabytes(bytes)} MB");
            }
            else
            {
                Console.WriteLine($"{ByteConverter.BytesToKilobytes(bytes)} KB");
            }
        }

        static void PrintStringsArray(string[] array, string prefix = "", string suffix = "")
        {
            foreach (string value in array)
            {
                Console.WriteLine($"{prefix}{value}{suffix}");
            }
        }
    }
}
