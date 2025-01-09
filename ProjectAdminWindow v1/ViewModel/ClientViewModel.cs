using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Net.Http.Json;

namespace ProjectAdminWindow_v1.ViewModel
{
    public class ClientsViewModel : INotifyPropertyChanged
    {
    private ObservableCollection<Client> _clients;
        private readonly HttpClient _client;

        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set
            {
                _clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }

        public ClientsViewModel()
        {
            _client = new HttpClient();
            LoadClients();
        }

        private async void LoadClients()
        {
            // Загрузка данных из базы данных
            // Примерный URL API для получения данных
            var response = await _client.GetAsync("http://example.com/api/clients");
            if (response.IsSuccessStatusCode)
            {
                var clientsData = await response.Content.ReadAsAsync<List<Client>>();
                Clients = new ObservableCollection<Client>(clientsData);
            }
        }

        public async void ConfirmClient(Client client)
        {
            client.Status = "Проверка пройдена";
            await UpdateClientStatus(client);
        }

        public async void RejectClient(Client client)
        {
            client.Status = "Проверка не пройдена";
            await UpdateClientStatus(client);
        }

        private async Task UpdateClientStatus(Client client)
        {
            // Отправка обновленного состояния клиента на сервер
            await _client.PutAsJsonAsync($"http://example.com/api/clients/{client.EGRN}", client);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
