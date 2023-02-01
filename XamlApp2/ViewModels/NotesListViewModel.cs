using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using XamlApp2.Views;

namespace XamlApp2.ViewModels
{
    public class NotesListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<NotesViewModel> Notes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateNoteCommand { protected set; get; }
        public ICommand DeleteNoteCommand { protected set; get; }
        public ICommand SaveNoteCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        NotesViewModel selectedNote;

        public INavigation Navigation { get; set; }

        public NotesListViewModel()
        {
            Notes = new ObservableCollection<NotesViewModel>();
            CreateNoteCommand = new Command(CreateNote);
            DeleteNoteCommand = new Command(DeleteNote);
            SaveNoteCommand = new Command(SaveNote);
            BackCommand = new Command(Back);
        }

        public NotesViewModel SelectedNote
        {
            get { return selectedNote; }
            set
            {
                if (selectedNote != value)
                {
                    NotesViewModel tempNote = value;
                    selectedNote = null;
                    OnPropertyChanged("SelectedNote");
                    Navigation.PushAsync(new NotePage(tempNote));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void CreateNote()
        {
            Navigation.PushAsync(new NotePage(new NotesViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveNote(object noteObject)
        {
            NotesViewModel note = noteObject as NotesViewModel;
            if (note != null && note.IsValid && !Notes.Contains(note))
            {
                Notes.Add(note);
            }
            Back();
        }
        private void DeleteNote(object noteObject)
        {
            NotesViewModel note = noteObject as NotesViewModel;
            if (note != null)
            {
                Notes.Remove(note);
            }
            Back();
        }
    }
}
