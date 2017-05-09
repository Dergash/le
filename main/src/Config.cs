using System;
using System.IO;
using System.Collections;
using System.Linq;

using Microsoft.Extensions.Configuration;

namespace LE {
    public class Config {

        // Access through Root["section:key"];
        public static IConfigurationRoot Root { get; set; }

        public static void Build() {
            string configFolder = Path.Combine(Directory.GetCurrentDirectory(), "config");
            if (!Directory.Exists(configFolder)) {
                Directory.CreateDirectory(configFolder);
            }
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(configFolder);
            IEnumerable configFiles = Directory.GetFiles(configFolder)
                .Where(file => Path.GetExtension(file) == ".ini");
            foreach (string config in configFiles) {
                configBuilder.AddIniFile(config);
            }
            Config.Root = configBuilder.Build();
        } 
    }
}