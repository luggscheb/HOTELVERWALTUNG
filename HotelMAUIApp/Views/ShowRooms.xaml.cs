using HotelMAUIApp.ViewModels;


namespace HotelMAUIApp.Views;

public partial class ShowRooms : ContentPage
{

	private ShowRoomsViewModel _vm = new ShowRoomsViewModel();
	public ShowRooms()
	{
		InitializeComponent();
		this.BindingContext = _vm;
	}
}