using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace RegisterAutoitX3
{
    [RunInstaller(true)]
    public partial class Register : System.Configuration.Install.Installer
    {
        string sSource;
        string sLog;

        public Register()
        {
            InitializeComponent();
            sSource = "Lior.Crm.AutoItInstaller";
            sLog = "Lior.Crm";

            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);
        }

        public override void Install(IDictionary stateSaver)
        {
            string path = this.Context.Parameters["targetdir"];
            path = path.Replace("/", "");
            EventLog.WriteEntry(sSource, path);
            var dllPath = path + "AutoItX3.dll";
            if (!File.Exists(dllPath))
            {  // EventLog.WriteEntry(sSource, dllPath + "1 no found!!!", EventLogEntryType.Warning, 234);
                EventLog.WriteEntry(sSource, "1 no exist" + dllPath + " !!!", EventLogEntryType.Error, 234);

                throw new FileNotFoundException("no found " + dllPath);
            }
            else
            {
                EventLog.WriteEntry(sSource, dllPath + " exist", EventLogEntryType.Information, 234);
                Registar_Dlls(dllPath);
                EventLog.WriteEntry(sSource, "Registar Dlls", EventLogEntryType.Error, 234);

            }
            base.Install(stateSaver);

        }

        public override void Uninstall(IDictionary savedState)
        {
            string path = this.Context.Parameters["targetdir"];
            path = path.Replace("/", "");
            EventLog.WriteEntry(sSource, path);
            var dllPath = path + "AutoItX3.dll";
            if (!File.Exists(dllPath))
            {  // EventLog.WriteEntry(sSource, dllPath + "1 no found!!!", EventLogEntryType.Warning, 234);
                EventLog.WriteEntry(sSource, "1 no exist" + dllPath + " !!!", EventLogEntryType.Error, 234);

                //   throw new FileNotFoundException("no found " + dllPath);
            }
            else
            {
                EventLog.WriteEntry(sSource, dllPath + " exist", EventLogEntryType.Information, 234);

                UnRegistar_Dlls(dllPath);
                EventLog.WriteEntry(sSource, "UnRegistar Dlls", EventLogEntryType.Error, 234);

            }
            base.Uninstall(savedState);
        }

        public void Registar_Dlls(string filePath)
        {

            //'/s' : Specifies regsvr32 to run silently and to not display any message boxes.
            string fileinfo = "/s" + " " + "\"" + filePath + "\"";
            Process reg = new Process();
            //This file registers .dll files as command components in the registry.
            reg.StartInfo.FileName = "regsvr32.exe";
            reg.StartInfo.Arguments = fileinfo;
            reg.StartInfo.UseShellExecute = false;
            reg.StartInfo.CreateNoWindow = true;
            reg.StartInfo.RedirectStandardOutput = true;
            reg.Start();
            reg.WaitForExit();
            reg.Close();

        }

        public void UnRegistar_Dlls(string filePath)
        {

            //'/s' : Specifies regsvr32 to run silently and to not display any message boxes.
            string fileinfo = "/u" + " " + "\"" + filePath + "\"";
            Process reg = new Process();
            //This file registers .dll files as command components in the registry.
            reg.StartInfo.FileName = "regsvr32.exe";
            reg.StartInfo.Arguments = fileinfo;
            reg.StartInfo.UseShellExecute = false;
            reg.StartInfo.CreateNoWindow = true;
            reg.StartInfo.RedirectStandardOutput = true;
            reg.Start();
            reg.WaitForExit();
            reg.Close();

        }
    }
}
