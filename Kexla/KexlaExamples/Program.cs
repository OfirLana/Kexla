﻿using Kexla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KexlaExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var CimV2searcher = new WMISearcher(); //root\CimV2 is the defualt namespace



            #region read data under root\CimV2

            var networks = CimV2searcher.Query<NetworkAdapter>();
            foreach (var network in networks)
            {
                Console.WriteLine("NetworkAdapter Data :");
                Console.WriteLine(network);
            }

            var networkLoginProfiles = CimV2searcher.Query<NetworkLoginProfile>();
            foreach (var networkLoginProfile in networkLoginProfiles)
            {
                Console.WriteLine("NetworkLoginProfile Data :");
                Console.WriteLine(networkLoginProfile);
            }
            #endregion


            #region execute methods under root\CimV2

            var printer = CimV2searcher.Query<Printer>().Where(x => x.Name == "Brother RJ-4030").FirstOrDefault();
            if (printer != null)

                printer.RenamePrinter(newName: "Brother RJ-4030xXx");
            #endregion

            var wmiSearcher = new WMISearcher(@"Root\wmi");


            #region  read data under Root\wmi


            var monitorBrightness = wmiSearcher.Query<WmiMonitorBrightness>();
            foreach (var monitor in monitorBrightness)
            {
                Console.WriteLine(monitor);
            }
            #endregion

            #region execute methods under Root\wmi

            var monitorBrightnessMethods = wmiSearcher.Query<WmiMonitorBrightnessMethods>();
            foreach (var method in monitorBrightnessMethods)
            {
                Console.WriteLine(method);
                method.WmiSetBrightness(Timeout: UInt32.MaxValue, Brightness: 100);
            }

            #endregion

            Console.ReadKey();
        }
    }
}
