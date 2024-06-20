namespace JokenPo.Views;
using JokenPo.ViewModel;

public partial class GameView : ContentPage
{
	public GameView()
	{
		InitializeComponent();
		BindingContext = new GameViewModel();
	}
}