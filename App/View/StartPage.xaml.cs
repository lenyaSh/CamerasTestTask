using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.ViewModel;
using System.ComponentModel;

namespace App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            BindingContext = this;
            IsBusy = false;
        }
        private async void ConnectToServer(object sender, EventArgs e)
        {
            IsBusy = true;
            try
            {
                ServerDataViewModel server = new ServerDataViewModel();
                server.GetData();


                await Navigation.PushAsync(new CameraListPage(server.c_vm));
                Navigation.RemovePage(this);
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await DisplayAlert("Ошибка получения данных с сервера", "Текст ошибки:\n" + ex.Message, "ОK");
            }
        }
    }
}