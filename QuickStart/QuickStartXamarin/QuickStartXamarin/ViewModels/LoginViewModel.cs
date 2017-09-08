using System;
namespace QuickStartXamarin.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _userName;
        private string _login;

        public SyncCommand<string> SetUserNameCommand;
        public ReverseCommand<string> NavigateToListPage;

        public LoginViewModel()
        {
            SetUserNameCommand = new SyncCommand<string>(ShowListSpeeches);
            NavigateToListPage = new ReverseCommand<string>();
        }

        private void ShowListSpeeches(string obj)
        {
            // save login to file

            NavigateToListPage.Execute(obj);
        }
    }
}
