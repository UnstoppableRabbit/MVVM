using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace kontur_niirs.ViewModel
{
    public class BriefViewModel : INotifyPropertyChanged
    { 
        private bool check;
        public bool Check
        {
            get { return check; }
            set
            {
                check = value;
                OnPropertyChanged("Check");
                Check1 = check;
            }
        }
        public bool Check1
        {
            get { return !check; }
            set
            {
                check = value;
                OnPropertyChanged("Check1");
            }
        }

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

        private string summ = "Результат умножения";
        public string Summ
        {
            get { return summ; }
            set
            {
                summ = value;
                OnPropertyChanged("Summ");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private MyCommand multCommand;
        public MyCommand MultCommand
        {
            get
            {
                return multCommand ??
                  (multCommand = new MyCommand(obj =>
                  {
                          Summ = GetString((decimal)X * (decimal)Y);
                  }, obj => Check1));
            }
        }
        public static string GetString(decimal number)
        {
            if (number > uint.MaxValue)
                return "Слишком большое число";
            string fStr = "";
            uint[] digits = number.ToString().Select(c => (uint)char.GetNumericValue(c)).ToArray();
            foreach(var i in digits) {
                switch (i)
                {
                    case 0:
                        fStr += "zero ";
                        break;
                    case 1:
                        fStr += "one ";
                        break;
                    case 2:
                        fStr += "two ";
                        break;
                    case 3:
                        fStr += "three ";
                        break;
                    case 4:
                        fStr += "four ";
                        break;
                    case 5:
                        fStr += "five ";
                        break;
                    case 6:
                        fStr += "six ";
                        break;
                    case 7:
                        fStr += "seven ";
                        break;
                    case 8:
                        fStr += "eight ";
                        break;
                    case 9:
                        fStr += "nine ";
                        break;
                }
            }
            return fStr;
        }
    }
}
