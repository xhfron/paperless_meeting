using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pm_client.util
{
    public class ChoiceResultViewData : INotifyPropertyChanged {
        static Random r = new Random();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }
        private string _option;


        public string option {

            get {
                return _option;
            }
            set {
                _option = value;
                OnPropertyChanged(new PropertyChangedEventArgs("option"));
            }
        }
        private int _percent;


        public int percent {

            get {
                return _percent;
            }
            set {
                _percent = value;
                OnPropertyChanged(new PropertyChangedEventArgs("percent"));
            }
        }
        private int _number;


        public int number {

            get {
                return _number;
            }
            set {
                _number = value;
                OnPropertyChanged(new PropertyChangedEventArgs("number"));
            }
        }
        private int _total;


        public int total {

            get {
                return _total;
            }
            set {
                _total = value;
                OnPropertyChanged(new PropertyChangedEventArgs("total"));
            }
        }
        private int _optionId;


        public int optionId {

            get {
                return _optionId;
            }
            set {
                _optionId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("optionId"));
            }
        }

        public void load(ChoiceResultViewData b) {
            this.option = b.option;
            this.percent = b.percent;
            this.number = b.number;
            this.total = b.total;
            this.optionId = b.optionId;

        }
    }
    class RemoteApp : INotifyPropertyChanged {
        static Random r = new Random();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }
        private string _absolutePath;


        public string absolutePath {

            get {
                return _absolutePath;
            }
            set {
                _absolutePath = value;
                OnPropertyChanged(new PropertyChangedEventArgs("absolutePath"));
            }
        }
        private string _name;


        public string name {

            get {
                return _name;
            }
            set {
                _name = value;
                OnPropertyChanged(new PropertyChangedEventArgs("name"));
            }
        }
        private System.Windows.Media.Imaging.BitmapImage _iconPath;


        public System.Windows.Media.Imaging.BitmapImage iconPath {

            get {
                return _iconPath;
            }
            set {
                _iconPath = value;
                OnPropertyChanged(new PropertyChangedEventArgs("iconPath"));
            }
        }

        public void load(RemoteApp b) {
            this.absolutePath = b.absolutePath;
            this.name = b.name;
            this.iconPath = b.iconPath;

        }
    }
}
