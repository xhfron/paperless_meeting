using Microsoft.Win32;
using pm_client.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pm_client.view
{
    /// <summary>
    /// remote.xaml 的交互逻辑
    /// </summary>
    public partial class remote : UserControl
    {
        public remote()
        {
            InitializeComponent();


            List<RegistryKey> RegistryKeys = new List<RegistryKey>();
            RegistryKeys.Add(Registry.ClassesRoot);
            RegistryKeys.Add(Registry.CurrentConfig);
            RegistryKeys.Add(Registry.CurrentUser);
            RegistryKeys.Add(Registry.LocalMachine);
            RegistryKeys.Add(Registry.PerformanceData);
            RegistryKeys.Add(Registry.Users);
            Dictionary<string, string> Softwares = new Dictionary<string, string>();
            string[] names = { @"Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall", @"Software\Microsoft\Windows\CurrentVersion\Uninstall" };
            foreach(string SubKeyName in names) {
                foreach (RegistryKey Registrykey in RegistryKeys) {
                    using (RegistryKey RegistryKey1 = Registrykey.OpenSubKey(SubKeyName, false)) {
                        if (RegistryKey1 == null) // 判断对象不存在
                            continue;
                        if (RegistryKey1.GetSubKeyNames() == null)
                            continue;
                        string[] KeyNames = RegistryKey1.GetSubKeyNames();
                        foreach (string KeyName in KeyNames)// 遍历子项名称的字符串数组
                        {
                            using (RegistryKey RegistryKey2 = RegistryKey1.OpenSubKey(KeyName, false)) // 遍历子项节点
                            {
                                if (RegistryKey2 == null)
                                    continue;
                                string SoftwareName = RegistryKey2.GetValue("DisplayName", "").ToString(); // 获取软件名
                                string InstallLocation = RegistryKey2.GetValue("InstallLocation", "").ToString(); // 获取安装路径
                                if (!string.IsNullOrEmpty(InstallLocation)
                                 && !string.IsNullOrEmpty(SoftwareName)) {
                                    if (!Softwares.ContainsKey(SoftwareName))
                                        Softwares.Add(SoftwareName, InstallLocation);
                                }
                            }
                        }
                    }
                }
            }
            
            foreach (string SoftwareName in Softwares.Keys) {
                Log.i("remote", $"app:{SoftwareName} path:{Softwares[SoftwareName]}");
            }
            if (true) return;


            FileInfo remoteApp=FileUtil.getFile(Settings.remoteFilePath);
            StreamReader streamReader=new StreamReader(remoteApp.OpenRead());
            string s = streamReader.ReadLine();
            while (s != null) {




                FileInfo exeFile = new FileInfo(s);
                
                Button btn = new Button();
                btn.Style = (Style)FindResource("remoteAppBtn");
                this.app_panel.Children.Add(btn);
            }
        }
    }
}
