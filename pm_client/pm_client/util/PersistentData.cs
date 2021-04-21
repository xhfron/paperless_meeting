using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pm_client.util
{
    class ChoiceResult : INotifyPropertyChanged {
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

        public void load(ChoiceResult b) {
            this.option = b.option;
            this.percent = b.percent;
            this.number = b.number;
            this.total = b.total;
            this.optionId = b.optionId;

        }
    }
    class RemoteApp : INotifyPropertyChanged
    {
        static Random r = new Random();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
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
        private string _path;


        public string path {

            get {
                return _path;
            }
            set {
                _path = value;
                OnPropertyChanged(new PropertyChangedEventArgs("path"));
            }
        }

        public void load(RemoteApp b) {
            this.name = b.name;
            this.path = b.path;

        }
    }
}
