using LgpDuvidas.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LgpDuvidas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginPageViewModel vm;

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = vm = new LoginPageViewModel();
        }
    }
}