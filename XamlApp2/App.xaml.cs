
using XamlApp2.Views;

namespace XamlApp2
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new NotesListPage());
        }

        protected override void OnStart()
        { }

        protected override void OnSleep()
        { }

        protected override void OnResume()
        { }
    }
}