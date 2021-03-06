﻿using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;


namespace TestControllerManager
{
    [Serializable, XmlType("Configuration")]
    public class Configuration : IConfiguration
    {
        public Uri TpcUri { get { return myLoadedConfiguration.TpcUri; } }
        public string TeamProject { get { return myLoadedConfiguration.TeamProject; } }
        public string Favourites { get { return myLoadedConfiguration.Favourites; } }
        public bool AgentMonitoringEnabled { get { return myLoadedConfiguration.AgentMonitoringEnabled; } }
        public int Port { get { return myLoadedConfiguration.Port; } }
        public string DomainSuffix { get { return myLoadedConfiguration.DomainSuffix; } }

        private readonly IConfiguration myLoadedConfiguration;

        public Configuration()
        {
            var loader = new ConfigurationLoader();
            myLoadedConfiguration = loader.Load() ?? new DefaultConfiguration();
        }

        public void Save()
        {
            var writer = new ConfigurationWriter();
            writer.Write(this);
        }
    }

    public class ConfigurationHandler
    {
        public static string FileName
        {
            get
            {
                var str = Path.Combine(
                    Environment.GetEnvironmentVariable("LOCALAPPDATA"),
                    Assembly.GetExecutingAssembly().GetName().Name + ".xml");
                if (str.StartsWith(@"file:\"))
                {
                    str = str.Substring(6);
                }
                return str;
            }
        }
        public static XmlSerializer Serializer
        {
            get { return new XmlSerializer(typeof(Configuration)); }
        }
    }

    public class ConfigurationLoader : ConfigurationHandler
    {
        public IConfiguration Load()
        {
            if (!File.Exists(FileName)) return null;
            using (var stream = File.Open(FileName, FileMode.Open))
            {
                return (IConfiguration)Serializer.Deserialize(stream);
            }
        }
    }

    public class ConfigurationWriter : ConfigurationHandler
    {
        public void WriteDefaults(IConfiguration src)
        {
            Write(new DefaultConfiguration());
        }

        public void Write(IConfiguration currentConfiguration)
        {
            using (var writer = new StreamWriter(FileName))
            {
                Serializer.Serialize(writer, currentConfiguration);
            }
        }

    }

}
