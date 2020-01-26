using System;
using System.IO;

namespace OrderSushi
{
    public class EmailTemplates: Messager
    {
        public string CreateCheckEmail(string userName, string stringEmailCheck, string botname)
        {
            string letter = "<html>" +
                           "<head>" +
                           "<title>HTML-Document</title>"+
                           "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />"+
                           "</head>"+
                           "<body>"+
                           "Hi "+ userName + "!"+
                           "<p> <p> Thank you for ordering sushi in our sushi bar. Please review your order:"+
                           "<pre>" + stringEmailCheck + "</pre>" +
                           "<p> Sincerely, " + botName +
                           "</body>" +
                           "</html>";
            return letter;               
        }
        public string CreateConfirmEmail( string userName, string securityCode )
        {
            
            string letter = "<html>" +
                           "<head>" +
                           "<title>HTML-Document</title>"+
                           "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />"+
                           "</head>"+
                           "<body>"+
                           "Hi "+ userName + "!"+
                           "<p> <p> A OrderSushi account"+
                           "<p> Security code" +
                           "<p> Use the following security code for your OrderSushi " + userName + " account."  +
                           "<p> Security code: " + securityCode + "." +
                           "<p> If you didn't request this code, you can safely ignore this email message."+
                           "<br> Someone may have entered your email address by mistake." +
                           "<p> With respect, " + botName +
                           "</body>" +
                           "</html>";

            return letter;
        }
    }
}
