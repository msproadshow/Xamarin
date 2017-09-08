using System;
using Newtonsoft.Json;
using Xamarin.Forms;
namespace QuickStartXamarin.Models
{
    public class Speech
    {
        public string Descriprion { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
        public string Type { get; set; }
        public Speaker speaker { get; set; }
        public int Id { get; set; }
    }
}
