using Microsoft.Win32;
using pm_client.util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
    public partial class remote : UserControl, MessageListener {
        public Dictionary<string,string> findAllApp() {
            List<RegistryKey> RegistryKeys = new List<RegistryKey>();
            RegistryKeys.Add(Registry.ClassesRoot);
            RegistryKeys.Add(Registry.CurrentConfig);
            RegistryKeys.Add(Registry.CurrentUser);
            RegistryKeys.Add(Registry.LocalMachine);
            RegistryKeys.Add(Registry.PerformanceData);
            RegistryKeys.Add(Registry.Users);
            Dictionary<string, string> Softwares = new Dictionary<string, string>();
            string[] names = { @"Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall", @"Software\Microsoft\Windows\CurrentVersion\Uninstall" };
            foreach (string SubKeyName in names) {
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
            return Softwares;
        }
        string name = "remote";

        public void sendMode(object sender,RoutedEventArgs e) {
            if (this.remoteSwitchButton.Content == "开启应用") {
                try {
                    WebUtil.remoteSwitch(ProcessManager.GRANTED);
                    this.remoteSwitchButton.Content = "关闭应用";
                } catch (NetworkException) {
                    ViewUtil.msg("权限变更失败");
                }
            } else {
                try {
                    WebUtil.remoteSwitch(ProcessManager.DENIED);
                    this.remoteSwitchButton.Content = "开启应用";
                } catch (NetworkException) {
                    ViewUtil.msg("权限变更失败");
                }
            }
        }

        public remote()
        {
            InitializeComponent();

            if (ViewUtil.Find<Role>(this, "role").name == "主持人") {
                this.remoteSwitchButton.Content = "开启应用";
                this.remoteSwitchButton.Click += sendMode;
            } else {
                this.remoteSwitchButton.Visibility = Visibility.Collapsed;
            }
            Dictionary<string, string> Softwares = findAllApp();//<name,home>
            
            foreach (string SoftwareName in Softwares.Keys) {
                Log.i("remote", $"app:{SoftwareName} path:{Softwares[SoftwareName]}");
                if (SoftwareName == "腾讯会议") {
                    Log.i(name, $"got {SoftwareName}");

                    string parent = new DirectoryInfo(Softwares[SoftwareName].Trim('"')).Parent.FullName;
                    string filepath = System.IO.Path.Combine(parent, "wemeetapp.exe");

                    if(new FileInfo(filepath).Exists) {
                        Icon resultIcon=Icon.ExtractAssociatedIcon(filepath);
                        RemoteApp app = new RemoteApp();
                        app.absolutePath = filepath;
                        app.iconPath = BitmapToBitmapImage(resultIcon.ToBitmap());
                        app.name = SoftwareName;

                        Button button = new Button();
                        button.Style = (Style)FindResource("remoteAppBtn");
                        button.DataContext = app;
                        button.Click += Button_Click;
                        this.app_panel.Children.Add(button);
                    }
                }
            }
            
        }
        private BitmapImage BitmapToBitmapImage(System.Drawing.Bitmap bitmap) {
            BitmapImage bitmapImage = new BitmapImage();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream()) {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
            }
            return bitmapImage;
        }
        private void Button_Click(object sender, RoutedEventArgs e) {
            if (mode == GRANTED) {
                if(sender is Button) {
                    RemoteApp app = ((Button)sender).DataContext as RemoteApp;
                    ProcessStartInfo processInfo=new ProcessStartInfo();
                    Process process = Process.Start(app.absolutePath);
                    
                }
            } else {
                ViewUtil.msg("打不开打不开打不开");
            }
        }

        public void onMessage(Dictionary<string, object> json) {
            string cmd = (string)json["cmd"];
            if (cmd.Contains("腾讯会议")) {
                int code = (int)json["code"];
                if (code == 2) {
                    mode = GRANTED;
                    this.remoteSwitchButton.Content = "关闭应用";
                } else {
                    this.remoteSwitchButton.Content = "开启应用";
                    mode = -GRANTED;
                }
            }
        }//end

        int GRANTED = 1;
        int mode = -1;
    }
}
