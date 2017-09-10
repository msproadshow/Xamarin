using Xamarin.Forms;
using QuickStartXamarin.ViewModels;
using QuickStartXamarin.Models;

namespace QuickStartXamarin.Views
{
    public partial class SpeakerPage : NavigationPage
    {
        private SpeakerViewModel ViewModel;

        public SpeakerPage(Speaker parametr)
        {
            InitializeComponent();
            ViewModel = new SpeakerViewModel(parametr);
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = ViewModel.Parametr as Speaker;
        }

        protected override void OnDisappearing()
        {
            BindingContext = null;

            base.OnDisappearing();
        }
    }
}
