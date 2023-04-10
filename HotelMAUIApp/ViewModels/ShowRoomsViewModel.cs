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
    internal class ShowRoomsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Room> _rooms;
        private string _responseText;

        public ObservableCollection<Room> Rooms
        {
            get { return _rooms; }
            set { 
            
                if(value != this._rooms)
                {
                    this._rooms = value;
                    OnPropertyChanged();

                }
            }
        }
        public string ResponseText
        {
            get { return _responseText; }
            set
            {
                if(value != this._responseText)
                {
                    this._responseText = value;
                    OnPropertyChanged();
                }
            }
        }

        public ShowRoomsViewModel()
        {
            CmdShowArticle = new Command(OnShowArticle);
            
        }

        public ICommand CmdShowArticle { get; private set; }

        private void OnShowArticle()
        {
            HttpClient client = new HttpClient();
            var response = client.GetFromJsonAsync<List<Room>>("https://localhost:7015/api/hotel/rooms").Result;

            if (response != null)
            {
                this.ResponseText = "OK";
                this.Rooms = new ObservableCollection<Room>();
                response.ForEach(a => this.Rooms.Add(a));   
                
            }
            else
            {
                this.ResponseText = "Fehler";
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
