using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NotifyPropertyChangedCallerMemberName
{
    public class NotifyPropertyBaseCallerMemberInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}