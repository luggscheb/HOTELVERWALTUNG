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
    public class AddReservationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime _startdate = DateTime.Now;
        private DateTime _enddate = DateTime.Now;
        private Room _room;
        private Customer _customer;
        private string _responcetext;

        public string ResponseText
        {
            get { return _responcetext; }
            set
            {
                if (_responcetext != value)
                {
                    _responcetext = value;
                    OnPropertyChanged();
                }
            }
        }

        public Room room
        {
            get { return this._room; }
            set
            {
                if(this._room != value)
                {
                    this._room = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime startdate
        {
            get { return this._startdate; }
            set
            {
                if(value != this._startdate)
                {
                    this._startdate = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime enddate
        {
            get { return this._enddate; }   
            set
            {
                if(value != this._enddate)
                {
                    this._enddate = value;
                    OnPropertyChanged();
                }
            }
        }

        

        public Customer customer
        {
            get { return this._customer; }
            set
            {
                if(value != this._customer)
                {
                    this._customer= value;
                    OnPropertyChanged();
                }
            }
        }

        public List<Customer> AllCustomers
        {
            get
            {
                // alle enum-Werte von Category in eine List<string> konvertieren
                HttpClient client = new HttpClient();
                var response = client.GetFromJsonAsync<List<Customer>>("https://localhost:7015/api/hotel/customer").Result;
                return response;
            }
        }

        public List<Room> AllRooms
        {
            get 
            {
                HttpClient client = new HttpClient();
                var response = client.GetFromJsonAsync<List<Room>>("https://localhost:7015/api/hotel/rooms").Result;
                return response;
            }
        }

        public AddReservationViewModel()
        {
            CmdCreateReservation = new Command(OnCreateReservation);
            CmdResetReservation = new Command(OnResetReservation);
        }

        
        public ICommand CmdCreateReservation { get; private set; }
        public ICommand CmdResetReservation { get; private set; }
        
        private void OnCreateReservation()
        {
            BillRoom c = new BillRoom()
            {
                StartDate = this.startdate,
                EndDate = this.enddate,
                CustomerId = this.customer.CustomerId,
                RoomId = this.room.RoomId

            };

            HttpClient client = new HttpClient();
            var response = client.PostAsJsonAsync<BillRoom>("https://localhost:7015/api/hotel/newBill", c).Result;
            if (response.IsSuccessStatusCode)
            {
                this.ResponseText = "OK";
            }
            else
            {
                this.ResponseText = "Fehler";
            }
            OnResetReservation();
        }
        private void OnResetReservation()
        {


            this.startdate = DateTime.Now;
            this.enddate = DateTime.Now;
            this.customer = new Customer();
            this.room = new Room();
 

        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
