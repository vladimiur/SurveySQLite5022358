using pruebni.Views;

namespace pruebni;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(SurveyDetailsView), typeof(SurveyDetailsView));
    }
}
