using System;
using QuickStartXamarin.Models;
namespace QuickStartXamarin.ViewModels
{
    public class SpeakerViewModel : ViewModelBase
    {
        public SpeakerViewModel(Speaker parametr)
        {
            base.Start(parametr);
        }
    }
}
