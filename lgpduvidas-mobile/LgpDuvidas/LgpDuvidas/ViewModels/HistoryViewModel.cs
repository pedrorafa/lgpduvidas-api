using LgpDuvidas.Interfaces;
using LgpDuvidas.Models;
using LgpDuvidas.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace LgpDuvidas.ViewModels
{
    public class HistoryViewModel : INotifyPropertyChanged
    {
        private IAnalyticsService _analyticsService => DependencyService.Get<IAnalyticsService>();
        public IAuthService _authService => DependencyService.Get<IAuthService>();
        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }
        public string Title { get; set; }
        private List<Entity> _itens { get; set; }
        public List<Entity> Entities
        {
            get { return _itens; }
            set
            {
                _itens = value;
                OnPropertyChanged();
            }
        }

        private Entity _ItemSelected;
        public Entity ItemSelected
        {
            get
            {
                return _ItemSelected;
            }
            set
            {
                if (_ItemSelected != value)
                {
                    _ItemSelected = value;
                    OnOpenEntity();
                }
            }
        }
        public ICommand OpenEntity { get; }
        public HistoryViewModel()
        {
            Title = "History";
            OpenEntity = new Command(OnOpenEntity);
            IsLoading = true;
            LoadMessages();
        }

        public void OnAppearing()
        {
            //IsLoading = true;
            //LoadMessages();
        }

        public async void LoadMessages()
        {
            int erroCount = 0;
            var items = await _analyticsService.GetMessages();
            while (items == null && erroCount < 2)
            {
                erroCount++;
                await _authService.Refresh();
                items = await _analyticsService.GetMessages();
            }
            if (items != null)
                Entities = items.ToList();
            IsLoading = false;
        }

        private async void OnOpenEntity()
        {
            var page = new MessagesPage(_ItemSelected.Description, _ItemSelected.Messages.ToList());
            await Shell.Current.Navigation.PushAsync(page);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}