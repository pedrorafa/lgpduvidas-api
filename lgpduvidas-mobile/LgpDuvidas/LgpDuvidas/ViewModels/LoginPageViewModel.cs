using LgpDuvidas.Interfaces;
using LgpDuvidas.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LgpDuvidas.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public IAuthService _authService => DependencyService.Get<IAuthService>();
        public AuthModel UserModel { get; set; }

        private bool _hasConnection;
        public bool HasConnection
        {
            get {
                var current = Connectivity.NetworkAccess;

                _hasConnection = current == NetworkAccess.Internet;
                return _hasConnection;
            }
        }

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

        private bool _hasError;
        public bool HasError
        {
            get { return _hasError; }
            set
            {
                _hasError = value;
                OnPropertyChanged();
            }
        }
        public ICommand Login { get; }

        public LoginPageViewModel()
        {
            IsLoading = false;
            HasError = false;
            UserModel = new AuthModel();

            Login = new Command(OnLogin);
        }

        public void OnAppearing()
        {
            HasError = false;
        }

        private void OnLogin()
        {
            IsLoading = true;
            HasError = false;
            ToAuthentication();
        }

        public async void ToAuthentication()
        {
            var authRequest = await _authService.Login(UserModel);
            UserModel = authRequest;

            if (string.IsNullOrWhiteSpace(UserModel.Token))
            {
                IsLoading = false;
                HasError = true;
                return;
            }
            await Shell.Current.GoToAsync("//ChatPage");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}