using Hotel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelMAUIApp.ViewModels
{
    public class ShowReservationsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<BillRoom> _bills;
        private string _responseText;

        public ObservableCollection<BillRoom> Bills
        {
            get { return _bills; }
            set {
                if (value != this._bills)
                {
                    this._bills = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ResponseText
        {
            get { return _responseText; }
            set
            {
                if (value != this._responseText)
                {
                    this._responseText = value;
                    OnPropertyChanged();

                }
            }
        }

        public ShowReservationsViewModel()
        {
            CmdShowRes = new Command(OnShowRes);
        }

        public ICommand CmdShowRes { get; private set; }

        private void OnShowRes()
        {
            HttpClient client = new HttpClient();
            var response = client.GetFromJsonAsync<List<BillRoom>>("https://localhost:7015/api/hotel/bills").Result;
            
            if(response != null)
            {
                this.ResponseText = "OK";
                this.Bills= new ObservableCollection<BillRoom>();
                response.ForEach(a => this.Bills.Add(a));
            }
            else
            {
                this.ResponseText="FEHLER";
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
