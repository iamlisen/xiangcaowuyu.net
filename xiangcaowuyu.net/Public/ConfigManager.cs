﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace xiangcaowuyu.net.Public
{

    public class SysConfig
    {
        public string SysName { get; set; }
        public string QQ { get; set; }
        public string Email { get; set; }
        public string weibo { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string keywords { get; set; }
        public string description { get; set; }
    }

    public static class ConfigManager
    {
        private static IConfiguration configuration = null;
        static ConfigManager()
        {
            configuration = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", false, true).Build();
        }

        public static string GetConfig(string key)
        {
            string value = string.Empty;
            SysConfig sysConfig = new SysConfig();
            configuration.GetSection("SysConfig").Bind(sysConfig);
            Type type = typeof(SysConfig);
            return type.GetProperty(key).GetValue(sysConfig).ToString();
        }

    }
}
