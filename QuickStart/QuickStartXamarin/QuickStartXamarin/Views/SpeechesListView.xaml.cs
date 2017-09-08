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
            list.ItemsSource = ViewModel.Speeches;
        }

        private void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var item = e.Item as Speech;

            if (item != null)
                ViewModel.SelectedItemCommand.Execute(item.Id);
        }
    }
}
