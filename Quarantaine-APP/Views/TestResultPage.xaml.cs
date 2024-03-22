using Quarantaine_APP.ViewModels;

namespace Quarantaine_APP.Views;

public partial class TestResultPage : ContentPage
{
	public TestResultPage(TestResultViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}