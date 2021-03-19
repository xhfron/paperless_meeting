using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pm_client.util
{
    public class StringList : List<string>
    {

    }
    class Meeting : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        private string id;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Id"));
            }
        }

        private string character;
        public string Character
        {
            get
            {
                return character;
            }
            set
            {
                character = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Character"));
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Title"));
            }
        }

        private long timestart;
        public long TimeStart
        {
            get
            {
                return timestart;
            }
            set
            {
                timestart = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TimeStart"));
            }
        }

        private long timeend;
        public long TimeEnd
        {
            get
            {
                return timeend;
            }
            set
            {
                timeend = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TimeEnd"));
            }
        }

        public static Meeting mock()
        {
            Meeting res = new Meeting();
            Random r = new Random();


            res.Id = "Id_" + r.Next();

            res.Character = "Character_" + r.Next();

            res.Title = "Title_" + r.Next();
            res.TimeStart = r.Next();
            res.TimeEnd = r.Next();
            return res;
        }
    }

    class Vote : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Title"));
            }
        }

        private string state;
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnPropertyChanged(new PropertyChangedEventArgs("State"));
            }
        }

        private long timestart;
        public long TimeStart
        {
            get
            {
                return timestart;
            }
            set
            {
                timestart = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TimeStart"));
            }
        }

        private long timeend;
        public long TimeEnd
        {
            get
            {
                return timeend;
            }
            set
            {
                timeend = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TimeEnd"));
            }
        }

        private int maxcount;
        public int MaxCount
        {
            get
            {
                return maxcount;
            }
            set
            {
                maxcount = value;
                OnPropertyChanged(new PropertyChangedEventArgs("MaxCount"));
            }
        }

        private string votetype;
        public string VoteType
        {
            get
            {
                return votetype;
            }
            set
            {
                votetype = value;
                OnPropertyChanged(new PropertyChangedEventArgs("VoteType"));
            }
        }

        private StringList choices;
        public StringList Choices
        {
            get
            {
                return choices;
            }
            set
            {
                choices = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Choices"));
            }
        }

        public static Vote mock()
        {
            Vote res = new Vote();
            Random r = new Random();


            res.Title = "Title_" + r.Next();

            res.State = "State_" + r.Next();
            res.TimeStart = r.Next();
            res.TimeEnd = r.Next();
            res.MaxCount = r.Next();

            res.VoteType = "VoteType_" + r.Next();
            res.Choices = new StringList();
            for (int i = 0; i <= 2 || r.Next(0, 2) != 1; i++)
            {
                res.Choices.Add("Choices_" + r.Next());
            }
            return res;
        }
    }


    class VoteChoiceResult : INotifyPropertyChanged
    {
        static Random r = new Random();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        private int total;
        public int Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Total"));
            }
        }

        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Text"));
            }
        }

        private int count;
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            }
        }

        public static VoteChoiceResult mock()
        {
            VoteChoiceResult res = new VoteChoiceResult();

            res.Total = r.Next();

            res.Text = "Text_" + r.Next();
            res.Count = r.Next(0,100);
            return res;
        }
    }

}
