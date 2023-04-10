using Hotel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HotelMAUIApp.ViewModels
{
    class CreateCustomerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _VorName;
        private string _NachName;
        private int _alter;
        private string _email;
        private string _responseText;

        public string VorName
        {
            get { return _VorName; }
            set {
                if (value != this._VorName)
                {
                    // Wert neu zuweisen
                    this._VorName = value;
                    // Benachrichtigung auslösen
                    OnPropertyChanged();
                }
            }
        }
        public string NachName
        {
            get { return _NachName; }
            set
            {
                if(value != this._NachName)
                {
                    this._NachName = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Alter
        {
            get { return _alter; }
            set
            {
                if( value != this._alter)
                {
                    this._alter = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if(value != this._email)
                {
                    this._email = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ResponseText
        {
            get { return this._responseText; }
            set
            {
                if (value != this._responseText)
                {
                    this._responseText = value;
                    OnPropertyChanged();
                }
            }
        }

        public CreateCustomerViewModel()
        {
            CmdCreateCustomer = new Command(OnCreateCustomer);
            CmdResetCustomer = new Command(OnResetCustomer);
        }

        public ICommand CmdCreateCustomer { get; private set; }
        public ICommand CmdResetCustomer { get; private set; }

        private void OnCreateCustomer()
        {
            Customer c = new Customer()
            {
                VorName = this.VorName,
                NachName = this.NachName,
                Alter = this.Alter,
                Email = this.Email

            };

            HttpClient client = new HttpClient();
            var response = client.PostAsJsonAsync<Customer>("https://localhost:7015/api/hotel/newcustomer", c).Result;
            if (response.IsSuccessStatusCode)
            {
                this.ResponseText = "OK";
            }
            else
            {
                this.ResponseText = "Fehler";
            }
            OnResetCustomer();
        }
        private void OnResetCustomer()
        {


            this.VorName = "";
            this.NachName = "";
            this.Alter = 0;
            this.Email = "";

        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
