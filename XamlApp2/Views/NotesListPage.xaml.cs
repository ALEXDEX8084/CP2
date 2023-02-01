using XamlApp2.ViewModels;

namespace XamlApp2.Views
{
    public partial class NotesListPage : ContentPage
    {
        public NotesListPage()
        {
            InitializeComponent();
            BindingContext = new NotesListViewModel() { Navigation = this.Navigation };
        }
    }
}