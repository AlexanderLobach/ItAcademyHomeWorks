using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;
using NLog;

namespace OrderSushi
{
    public class InternetConn : Messager
    {
            public static bool TryPing(string hostNameOrAddress)
    {
          string pingStatusMessage;
          string pingAddressMessage;
         
        if (String.IsNullOrWhiteSpace(hostNameOrAddress))
        {
            pingStatusMessage = "Missing host name";
            pingAddressMessage = "";
            return false;
        }

        var data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        var buffer = Encoding.ASCII.GetBytes(data);
        var timeout = 1000;
        
        using (var p = new Ping())
        {
            var options = new PingOptions();
            options.DontFragment = true;
            try
            {
                var r = p.Send(hostNameOrAddress, timeout, buffer, options);
                if (r.Status == IPStatus.Success)
                {
                    pingStatusMessage = "Ping to " + hostNameOrAddress.ToString() + "[" + r.Address.ToString() + "]" + " (Successful) "
                      + "Bytes =" + r.Buffer.Length + " TTL=" + r.Options.Ttl + " Response delay = " + r.RoundtripTime.ToString() + " ms " + "\n";
                    pingAddressMessage = r.Address.ToString();
                    Console.WriteLine(pingAddressMessage);
                    return true;
                }
                else
                {
                    // just to know the ip for the website if they block the icmp protocol
                    pingStatusMessage = r.Status.ToString();
                    var ips = Dns.GetHostAddresses(hostNameOrAddress);

                    pingAddressMessage = hostNameOrAddress; //String.Join(",", ips.Select(ip => ip.ToString()));
                    return false;
                }
            }
            catch (PingException ex)
            {
                pingStatusMessage = string.Format("Error pinging {0}: {1}", hostNameOrAddress, (ex.InnerException ?? ex).Message);
                pingAddressMessage = hostNameOrAddress;
                return false;
            }
           
        }
        
         
    }
        public static bool ConnectionAvailable(string strServer)
        {
            int i = 0;
            i++;
            try
            {
                HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create(strServer);
  
                HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();
                if (HttpStatusCode.OK == rspFP.StatusCode)
                {
                    rspFP.Close();
                    return true;
                }
               else
                {
                    rspFP.Close();
                    return false;
                }
            }
            catch (WebException ex)
            {
                logger.Warn("No internet connection:" + ex);
                return false;
            }
        }


    
}
}

