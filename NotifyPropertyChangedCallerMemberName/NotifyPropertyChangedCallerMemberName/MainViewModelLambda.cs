namespace NotifyPropertyChangedCallerMemberName
{
    public class MainViewModelLambda : NotifyPropertyBaseLambda
    {
        private string _lambdaViewModel;

        public string LambdaViewModel
        {
            get { return _lambdaViewModel; }
            set
            {
                _lambdaViewModel = value;
                OnPropertyChanged(() => LambdaViewModel);
            }
        }
    }
}