using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace surveyVSS
{
   public class Hostname
    {
        public static string GetHostName()
        {
            string hostName = "";
            hostName = System.Net.Dns.GetHostName();
            Console.WriteLine("Tên của host này là :" + hostName);
            return hostName;
        }

        public static string GetDomain()
        {
            string domainName = "";
            domainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
            Console.WriteLine("Tên của domain này là :" + domainName);
            return domainName;
        }
    }
}
