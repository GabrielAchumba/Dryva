using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CusApp.Helpers
{
    public static class Constants
    {
        public const string DatabaseFilename = "DryvaCustomer.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }

        //public static string BaseAddress = Device.RuntimePlatform == Device.Android ? 
        public static string TodoRegistrationItemUrl = "http://10.0.2.2:44302/api/customers";
        public static string TodoWalletItemUrl = "http://10.0.2.2:44302/api/wallet";
        public static decimal MonthlyUnit = 2500;
        public static decimal WeeklyUnit = 750;

    }
}
