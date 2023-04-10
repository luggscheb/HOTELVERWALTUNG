using HotelMAUIApp.ViewModels;

namespace HotelMAUIApp.Views;

public partial class AddReservation : ContentPage
{
    private AddReservationViewModel _vm = new AddReservationViewModel();
    public AddReservation()
	{
		InitializeComponent();
        this.BindingContext = _vm;
    }
}