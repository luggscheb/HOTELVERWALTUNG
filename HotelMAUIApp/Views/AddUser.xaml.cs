using HotelMAUIApp.ViewModels;

namespace HotelMAUIApp.Views;

public partial class AddUser : ContentPage
{
    private CreateCustomerViewModel _vm = new CreateCustomerViewModel();
    public AddUser()
	{
		InitializeComponent();
        this.BindingContext = _vm;
    }
}