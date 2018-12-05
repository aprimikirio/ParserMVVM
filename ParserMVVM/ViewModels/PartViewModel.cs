using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using ParserMVVM.Models;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace ParserMVVM.ViewModels
{
    public class PartViewModel : INotifyPropertyChanged
    {
        PartsContext db = new PartsContext();

        private Part selectedPart;
        public ObservableCollection<Part> Parts { get; set; }
        public ObservableCollection<LinkPart> LinkParts { get; set; }

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
            StreamReader logFile = new StreamReader(@"..\..\links.txt");

            List<string> logLines = new List<string>();
            string line;

            while ((line = logFile.ReadLine()) != null)
            {
                logLines.Add(line);
            }

            logFile.Close();

            Parts = new ObservableCollection<Part>();
            LinkParts = new ObservableCollection<LinkPart>();

            foreach(string log in logLines)
            {
                Part addingPart = db.Parts.Where(a => a.Art.Replace(".", string.Empty) == log).FirstOrDefault();
                if (addingPart != null)
                {
                    foreach (LinkPart lPart in db.LinkParts.Where(a => a.PartArt == addingPart.Art))
                    {
                        addingPart.LinkArt = lPart.Art;
                        Parts.Add(addingPart);
                    }
                }
                else Parts.Add(new Part { Art = log, Name = "не найдено" });
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
