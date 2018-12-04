using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ParserMVVM.Models
{
    public class LinkPart : INotifyPropertyChanged
    {
        private int id { get; set; }
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string art { get; set; }
        public string Art
        {
            get { return art; }
            set
            {
                art = value;
                OnPropertyChanged("Art");
            }
        }

        private string partArt { get; set; }
        public string PartArt
        {
            get { return partArt; }
            set
            {
                partArt = value;
                OnPropertyChanged("PartArt");
            }
        }

        private Part part { get; set; }
        public Part Part
        {
            get { return part; }
            set
            {
                part = value;
                OnPropertyChanged("Part");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
