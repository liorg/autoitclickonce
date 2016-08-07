using AutoItX3Lib;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Web;

namespace ClickOnceAutoIt
{
    class Program
    {
        static string _version;
        static private NameValueCollection GetQueryStringParameters()
        {
            NameValueCollection nameValueTable = new NameValueCollection();

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                //  MessageBox.Show(ApplicationDeployment.CurrentDeployment.ActivationUri.AbsolutePath);
                string queryString = ApplicationDeployment.CurrentDeployment.ActivationUri != null ? ApplicationDeployment.CurrentDeployment.ActivationUri.Query : "";
                //MessageBox.Show(queryString);
                nameValueTable = HttpUtility.ParseQueryString(queryString);
            }
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                System.Deployment.Application.ApplicationDeployment ad =
                System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                _version = ad.CurrentVersion.ToString();
            }
            return (nameValueTable);
        }

        static void Main(string[] args)
        {
            IAutoItX3 au3 = new AutoItX3();
            var path = System.Configuration.ConfigurationManager.AppSettings["path"].ToString();
            var shortcut = System.Configuration.ConfigurationManager.AppSettings["shortcut"].ToString();
            var title = System.Configuration.ConfigurationManager.AppSettings["title"].ToString();

            if (au3.WinExists(title, "") == 0)
            {
                au3.Run(path, "", au3.SW_SHOW);    //run notepad
                au3.WinWaitActive(title, "");
            }
            else
                au3.WinActivate(title, "");
            var nameValue = GetQueryStringParameters();
            var dataToSend = "no send";
            if (nameValue != null && nameValue.Count > 0)
            {
                dataToSend = nameValue["d"];
            }
            au3.ClipPut(dataToSend);
            au3.Send(shortcut);
        }
    }
}
