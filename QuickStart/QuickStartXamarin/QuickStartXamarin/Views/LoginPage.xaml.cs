using System;
using System.Collections.Generic;

using Xamarin.Forms;
using QuickStartXamarin.ViewModels;

namespace QuickStartXamarin.Views
{
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel ViewModel;
        public LoginPage()
        {
            InitializeComponent();
            ViewModel = new LoginViewModel();
            ViewModel.Start();
        }


        //subscribe to VM events
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel != null)
            {
                ViewModel.NavigateToListPage.Executed += NavigateToListPage_Executed;
            }

            if (login_button != null)
                login_button.Clicked += Login_Button_Clicked;
        }


        //unsubscribe from vm events
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (ViewModel != null)
            {
                ViewModel.NavigateToListPage.Executed += NavigateToListPage_Executed;
            }
            if (login_button != null)
                login_button.Clicked -= Login_Button_Clicked;

            ViewModel = null;

          
        }

        private void NavigateToListPage_Executed(object sender, string e)
        {
            Navigation.PushModalAsync(new SpeechesListView());
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
           ViewModel.SetUserNameCommand.Execute("user");
        }

        private void Login_Button_Clicked(object sender, EventArgs e)
        {
            //
        }
    }
}
