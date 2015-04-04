namespace NotifyPropertyChangedCallerMemberName
{
    public class MainViewModelCallerMemberName : NotifyPropertyBaseCallerMemberInfo
    {
        private string _callerMemberNameViewModel;

        public string CallerMemberNameViewModel
        {
            get { return _callerMemberNameViewModel; }
            set
            {
                _callerMemberNameViewModel = value;
                OnPropertyChanged();
            }
        }
    }
}