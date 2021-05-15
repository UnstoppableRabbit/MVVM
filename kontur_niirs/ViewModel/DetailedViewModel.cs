using kontur_niirs.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace kontur_niirs.ViewModel
{
    public class DetailedViewModel : INotifyPropertyChanged
    {
        public DetailedViewModel()
        {
            Digits = new ObservableCollection<ListItem>();
        }
        public ObservableCollection<ListItem> Digits { get; set; }
 
        private uint x;
        public uint X
        {
            get { return x; }
            set
            {
                x = value;
                OnPropertyChanged("X");
            }
        }

        private uint y;
        public uint Y
        {
            get { return y; }
            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }

        private string summ = "ans";
        public string Summ
        {
            get { return summ; }
            set
            {
                summ = value;
                OnPropertyChanged("Summ");
            }
        }
        private MyCommand multCommand;
        public MyCommand MultCommand
        {
            get
            {
                return multCommand ??
                  (multCommand = new MyCommand(obj =>
                  {
                      Summ = ((decimal)X * Y).ToString();
                      Digits.Clear();
                      foreach(var x in GetList(Summ))
                      {
                          Digits.Add(x);
                      }
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public static ObservableCollection<ListItem> GetList(string number){

            ObservableCollection<ListItem> k = new ObservableCollection<ListItem>();
            var s = ViewModel.BriefViewModel.GetString(decimal.Parse(number));
            string[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach(var i in words)
            {
                k.Add(new ListItem { Digit = i});
            }
            return k;
        }
    }
}
