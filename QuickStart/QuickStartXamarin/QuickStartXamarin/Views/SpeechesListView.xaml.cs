using System;
using System.Collections.Generic;

using Xamarin.Forms;
using QuickStartXamarin.ViewModels;
using QuickStartXamarin.Models;

namespace QuickStartXamarin.Views
{
    public partial class SpeechesListView : ContentPage
    {
        private SpeechesListViewModel ViewModel;
        public SpeechesListView()
        {
            InitializeComponent();
            ViewModel = new SpeechesListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (list != null)
                list.ItemsSource = ViewModel.Speeches;

            if (ViewModel != null)
                ViewModel.ShowSpeakerCommand.Executed += OnShowSpeaker;
            
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (list != null)
                list.ItemsSource = null;

            if (ViewModel != null)
                ViewModel.ShowSpeakerCommand.Executed -= OnShowSpeaker;
            
            ViewModel = null;
        }

        private void OnShowSpeaker(object sender, Models.Speaker e)
        {
            var speaker = new SpeakerPage(e);
            var page = new NavigationPage(speaker);

        }

        private void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var item = e.Item as Speech;

            if (item != null)
                ViewModel.SelectedItemCommand.Execute(item.Id);
        }
    }
}
