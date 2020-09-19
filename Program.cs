using System;
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
                    Console.WriteLine($"Disk volume: {drive.TotalSize}");
                    Console.WriteLine($"Headspace: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Label: {drive.VolumeLabel}");
                }

                Console.WriteLine(new string('-', 32));
                Console.WriteLine();
            }
        }
    }
}
