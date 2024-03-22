using Quarantaine_APP.Views;

namespace Quarantaine_APP
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage),typeof(LoginPage));
            Routing.RegisterRoute(nameof(TestResultPage), typeof(TestResultPage));
        }
    }
}
