using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Infrastructure
{
    public static class Configuration
    {
        public static string RedisPort
        {
            get
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Core/MobilivaCase.EnvironmentConfiguration"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetSection("RedisSettings:Port").Value;

            }
        }
        public static (string MailSunucuAdresi, string MailSunucuPortu, string MailAdresi, string MailSifresi) MailConfig
        {
            get
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../../../../Core/MobilivaCase.EnvironmentConfiguration"));
                configurationManager.AddJsonFile("appsettings.json");
                var MailSunucuAdresi = configurationManager.GetSection("MailSettings:MailSunucuAdresi").Value;
                var MailSunucuPortu = configurationManager.GetSection("MailSettings:MailSunucuPortu").Value;
                var MailAdresi = configurationManager.GetSection("MailSettings:MailAdresi").Value;
                var MailSifresi = configurationManager.GetSection("MailSettings:MailSifresi").Value;

                return (MailSunucuAdresi, MailSunucuPortu, MailAdresi, MailSifresi);

            }
        }
    }
    
}
