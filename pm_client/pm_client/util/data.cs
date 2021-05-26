using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pm_client.util {


    class BtnData : INotifyPropertyChanged {
        static Random r = new Random();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }

        private string text;
        public string Text {
            get {
                return text;
            }
            set {
                text = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Text"));
            }
        }

        private string picdefault;
        public string picDefault {
            get {
                return picdefault;
            }
            set {
                picdefault = value;
                OnPropertyChanged(new PropertyChangedEventArgs("picDefault"));
            }
        }

        private string picchecked;
        public string picChecked {
            get {
                return picchecked;
            }
            set {
                picchecked = value;
                OnPropertyChanged(new PropertyChangedEventArgs("picChecked"));
            }
        }

        private string piccurrent;
        public string picCurrent {
            get {
                return piccurrent;
            }
            set {
                piccurrent = value;
                OnPropertyChanged(new PropertyChangedEventArgs("picCurrent"));
            }
        }

        public static BtnData mock() {
            BtnData res = new BtnData();


            res.Text = "Text_" + r.Next();

            res.picDefault = "picDefault_" + r.Next();

            res.picChecked = "picChecked_" + r.Next();

            res.picCurrent = "picCurrent_" + r.Next();
            return res;
        }
    }
    class SuperInfo : INotifyPropertyChanged {
        static Random r = new Random();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }
        private string _time;


        public string time {

            get {
                return _time;
            }
            set {
                _time = value;
                OnPropertyChanged(new PropertyChangedEventArgs("time"));
            }
        }

    }
    class File : INotifyPropertyChanged {
        static Random r = new Random();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }
        private int _id;


        public int id {

            get {
                return _id;
            }
            set {
                _id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("id"));
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
        private string _address;


        public string address {

            get {
                return _address;
            }
            set {
                _address = value;
                OnPropertyChanged(new PropertyChangedEventArgs("address"));
            }
        }

        public void load(File b) {
            this.id = b.id;
            this.name = b.name;
            this.address = b.address;

        }
    }
    public class VoteResult : INotifyPropertyChanged {
        static Random r = new Random();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
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
        private List<string> _devices;

        public List<string> devices {

            get {
                return _devices;
            }
            set {
                _devices = value;
                OnPropertyChanged(new PropertyChangedEventArgs("devices"));
            }
        }

    }
    public class VoteResultCollection : INotifyPropertyChanged {
        static Random r = new Random();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }
        private int _state;
        public int state {

            get {
                return _state;
            }
            set {
                _state = value;
                OnPropertyChanged(new PropertyChangedEventArgs("state"));
            }
        }
        private int _voteId;


        public int voteId {

            get {
                return _voteId;
            }
            set {
                _voteId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("voteId"));
            }
        }
        private List<VoteResult> _res;

        public List<VoteResult> res {

            get {
                return _res;
            }
            set {
                _res = value;
                OnPropertyChanged(new PropertyChangedEventArgs("res"));
            }
        }

    }
    public class RemoteState : INotifyPropertyChanged {
        static Random r = new Random();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }
        private string _state;


        public string state {

            get {
                return _state;
            }
            set {
                _state = value;
                OnPropertyChanged(new PropertyChangedEventArgs("state"));
            }
        }

    }
    public class Role : INotifyPropertyChanged {
        static Random r = new Random();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }
        private int _id;


        public int id {

            get {
                return _id;
            }
            set {
                _id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("id"));
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
        public void load(Role b) {
            this.id = b.id;
            this.name = b.name;
        }

    }
    class Meeting : INotifyPropertyChanged {
        static Random r = new Random();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }
        private int _meetingId;


        public int meetingId {

            get {
                return _meetingId;
            }
            set {
                _meetingId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("meetingId"));
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
        private string _content;


        public string content {

            get {
                return _content;
            }
            set {
                _content = value;
                OnPropertyChanged(new PropertyChangedEventArgs("content"));
            }
        }
        private string _beginTime;


        public string beginTime {

            get {
                return _beginTime;
            }
            set {
                _beginTime = value;
                OnPropertyChanged(new PropertyChangedEventArgs("beginTime"));
            }
        }
        private string _endTime;


        public string endTime {

            get {
                return _endTime;
            }
            set {
                _endTime = value;
                OnPropertyChanged(new PropertyChangedEventArgs("endTime"));
            }
        }
        private int _deviceId;


        public int deviceId {

            get {
                return _deviceId;
            }
            set {
                _deviceId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("deviceId"));
            }
        }
        private Role _role;


        public Role role {

            get {
                return _role;
            }
            set {
                _role = value;
                OnPropertyChanged(new PropertyChangedEventArgs("role"));
            }
        }

        public void load(Meeting b) {
            this.meetingId = b.meetingId;
            this.name = b.name;
            this.content = b.content;
            this.beginTime = b.beginTime;
            this.endTime = b.endTime;
            this.deviceId = b.deviceId;
            this.role = b.role;

        }
    }
    public class VoteOption : INotifyPropertyChanged {
        static Random r = new Random();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }
        private int _uid;


        public int uid {

            get {
                return _uid;
            }
            set {
                _uid = value;
                OnPropertyChanged(new PropertyChangedEventArgs("id"));
            }
        }
        private string _content;


        public string content {

            get {
                return _content;
            }
            set {
                _content = value;
                OnPropertyChanged(new PropertyChangedEventArgs("content"));
            }
        }
        public override string ToString() {
            return content;
        }

    }
    partial class Vote {
        public static int IDLE = -1;
        public static int VOTING = 0;
        public static int VOTED = -2;
    }
    public partial class Vote : INotifyPropertyChanged {
        static Random r = new Random();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }
        private int _uid;


        public int uid {

            get {
                return _uid;
            }
            set {
                _uid = value;
                OnPropertyChanged(new PropertyChangedEventArgs("uid"));
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
        private string _content;


        public string content {

            get {
                return _content;
            }
            set {
                _content = value;
                OnPropertyChanged(new PropertyChangedEventArgs("content"));
            }
        }
        private int _state;


        public int state {

            get {
                return _state;
            }
            set {
                _state = value;
                OnPropertyChanged(new PropertyChangedEventArgs("state"));
            }
        }
        private int _type;


        public int type {

            get {
                return _type;
            }
            set {
                _type = value;
                OnPropertyChanged(new PropertyChangedEventArgs("type"));
            }
        }
        private int _anonymous;


        public int anonymous {

            get {
                return _anonymous;
            }
            set {
                _anonymous = value;
                OnPropertyChanged(new PropertyChangedEventArgs("anonymous"));
            }
        }
        private int _meetingId;


        public int meetingId {

            get {
                return _meetingId;
            }
            set {
                _meetingId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("meetingId"));
            }
        }
        private List<VoteOption> _options;

        public List<VoteOption> options {

            get {
                return _options;
            }
            set {
                _options = value;
                OnPropertyChanged(new PropertyChangedEventArgs("options"));
            }
        }

        public void load(Vote b) {
            this.uid = b.uid;
            this.name = b.name;
            this.content = b.content;
            this.state = b.state;
            this.type = b.type;
            this.anonymous = b.anonymous;
            this.meetingId = b.meetingId;
            this.options = b.options;

        }
    }
    public class VoteList : INotifyPropertyChanged {
        static Random r = new Random();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }
        private List<Vote> _voteList;

        public List<Vote> voteList {

            get {
                return _voteList;
            }
            set {
                _voteList = value;
                OnPropertyChanged(new PropertyChangedEventArgs("voteList"));
            }
        }

    }

}
