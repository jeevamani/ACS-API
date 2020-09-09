using Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Interface
{
    public interface IConfigurationss
            {
        public List<InConfigurationDetails> GetConfiguration();
        public Result AddConfiguration(ConfigurationDetail inConfiguration);
        public Result UpdateConfiguration(ConfigurationDetail inConfiguration);
        public Result DeleteConfiguration(string Id);
        public List<ConfigurationMaster> GetConfigurationMasters();
        public Result AddConfigurationMaster(ConfigurationMaster configurationMaster);
        public Result UpdateConfigurationMaster(ConfigurationMaster configurationMaster);
        public Result DeleteConfigurationMaster(string ConfigId);
    }
}
