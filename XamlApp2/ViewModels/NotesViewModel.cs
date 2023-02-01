using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using XamlApp2.Models;
using XamlApp2;

namespace XamlApp2.ViewModels
{
    public class NotesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        NotesListViewModel lvm;

        public NotePad NotePad { get; private set; }

        public NotesViewModel()
        {
            NotePad = new NotePad();
        }

        public NotesListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
        public string Note
        {
            get { return NotePad.Note; }
            set
            {
                if (NotePad.Note != value)
                {
                    NotePad.Note = value;
                    OnPropertyChanged("Note");
                }
            }
        }
        public string NText
        {
            get { return NotePad.NText; }
            set
            {
                if (NotePad.NText != value)
                {
                    NotePad.NText = value;
                    OnPropertyChanged("NText");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return (!string.IsNullOrEmpty(Note.Trim())) || (!string.IsNullOrEmpty(NText.Trim()));
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
