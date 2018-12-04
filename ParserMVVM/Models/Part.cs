using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace ParserMVVM.Models
{
    public class Part : INotifyPropertyChanged
    {
        private string art;
        [Key]
        public string Art
        {
            get { return art; }
            set
            {
                art = value;
                OnPropertyChanged("Art");
            }
        }

        private string url { get; set; }
        public string Url
        {
            get { return url; }
            set
            {
                url = value;
                OnPropertyChanged("Url");
            }
        }

        private string brand { get; set; }
        public string Brand
        {
            get { return brand; }
            set
            {
                brand = value;
                OnPropertyChanged("Brand");
            }
        }

        private string name { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string specs { get; set; }
        public string Specs
        {
            get { return specs; }
            set
            {
                specs = value;
                OnPropertyChanged("Specs");
            }
        }

        /*
        public List<LinkPart> linkParts { get; set; }
        public List<LinkPart> LinkParts
        {
            get { return linkParts; }
            set
            {
                linkParts = value;
                OnPropertyChanged("LinkParts");
            }
        }
        */
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
