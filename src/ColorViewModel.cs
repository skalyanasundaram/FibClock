// -------------------------------------------------------------------------------------
// Defines ColorViewModel type
// Written by Kalyan <s.kalyanasundaram@gmail.com>
//
// This file is made available under terms of the GNU General Public License, version 2,
// or at your option, any later version, incorporated herein by reference.
// --------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows.Media;

namespace FibClock
{
    public class ColorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private Brush _valueFive;

        public Brush ValueFive
        {
            get
            {
                return _valueFive;
            }
            set
            {
                _valueFive = value;
                OnPropertyChanged("ValueFive");
            }
        }

        private Brush _valueThree;

        public Brush ValueThree
        {
            get
            {
                return _valueThree;
            }
            set
            {
                _valueThree = value;
                OnPropertyChanged("ValueThree");
            }
        }

        private Brush _valueTwo;

        public Brush ValueTwo
        {
            get
            {
                return _valueTwo;
            }
            set
            {
                _valueTwo = value;
                OnPropertyChanged("ValueTwo");
            }
        }

        private Brush _valueOneFirst;

        public Brush ValueOneFirst
        {
            get
            {
                return _valueOneFirst;
            }
            set
            {
                _valueOneFirst = value;
                OnPropertyChanged("ValueOneFirst");
            }
        }

        private Brush _valueOneSecond;

        public Brush ValueOneSecond
        {
            get
            {
                return _valueOneSecond;
            }
            set
            {
                _valueOneSecond = value;
                OnPropertyChanged("ValueOneSecond");
            }
        }
    }
}
