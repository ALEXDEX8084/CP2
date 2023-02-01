using XamlApp2.ViewModels;


namespace XamlApp2.Views
{
    public partial class NotePage : ContentPage
    {
        public NotesViewModel ViewModel { get; private set; }
        public NotePage(NotesViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}