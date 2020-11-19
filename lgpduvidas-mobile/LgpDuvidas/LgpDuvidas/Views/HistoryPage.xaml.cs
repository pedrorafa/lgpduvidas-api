using LgpDuvidas.ViewModels;
using Xamarin.Forms;

namespace LgpDuvidas.Views
{
    public partial class HistoryPage : ContentPage
    {
        HistoryViewModel vm;
        public HistoryPage()
        {
            BindingContext = vm = new HistoryViewModel();

            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.OnAppearing();
        }
    }
}