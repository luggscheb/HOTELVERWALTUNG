using HotelMAUIApp.ViewModels;

namespace HotelMAUIApp.Views;

public partial class ShowBills : ContentPage
{
    private ShowReservationsViewModel _vm = new ShowReservationsViewModel();

    public ShowBills()
	{
		InitializeComponent();
        this.BindingContext = _vm;

    }
}