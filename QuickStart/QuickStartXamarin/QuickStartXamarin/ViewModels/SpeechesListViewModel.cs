using System;
using System.Collections.Generic;
using QuickStartXamarin.Models;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using System.Collections.ObjectModel;

namespace QuickStartXamarin.ViewModels
{
    public class SpeechesListViewModel
    {
        public SyncCommand<int> SelectedItemCommand;
        public ReverseCommand<Speaker> ShowSpeakerCommand;

        public ObservableCollection<Speech> Speeches { get; private set; }

        public SpeechesListViewModel()
        {
            SelectedItemCommand = new SyncCommand<int>(SpeakerSelected);
            Speeches = new ObservableCollection<Speech>();
            ShowSpeakerCommand = new ReverseCommand<Speaker>();
            LoadSpeeches();
        }

        private void LoadSpeeches()
        {
			var assembly = typeof(App).GetTypeInfo().Assembly;
            var json = "";
            using (var reader = new StreamReader(assembly.GetManifestResourceStream("QuickStartXamarin.Speeches.json")))
			{
				json = reader?.ReadToEnd();
			}
            var result = JsonConvert.DeserializeObject<List<Speech>>(json);
            foreach (var item in result)
            {
                Speeches.Add(item);
            }
        }

        private void SpeakerSelected(int obj)
        {
            ShowSpeakerCommand.Execute(Speeches[obj].speaker);
        }
    }
}
