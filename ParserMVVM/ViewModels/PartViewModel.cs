using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using ParserMVVM.Models;
using System.Linq;

namespace ParserMVVM.ViewModels
{
    public class PartViewModel : INotifyPropertyChanged
    {
        PartsContext db = new PartsContext();

        private Part selectedPart;
        public ObservableCollection<Part> Parts { get; set; }
        
        public Part SelectedPart
        {
            get { return selectedPart; }
            set
            {
                selectedPart = value;
                OnPropertyChanged("SelectedPart");
            }
        }

        public PartViewModel()
        {
            Parts = new ObservableCollection<Part>
            {
                new Part { Art = db.Parts.FirstOrDefault().Art, Brand = db.Parts.FirstOrDefault().Brand, Name = db.Parts.FirstOrDefault().Name, Specs = "TestSpecs", Url = db.Parts.FirstOrDefault().Url }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
