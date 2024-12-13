using Microsoft.Maui.Controls;

namespace NativeLinkingRepo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
