using App.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraPage : ContentPage
    {
        public CameraViewModel ViewModel { get; private set; }

        public CameraPage(CameraViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            BindingContext = ViewModel;
        }
    }
}