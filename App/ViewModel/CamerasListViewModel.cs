using App.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace App.ViewModel
{
    public class CamerasListViewModel
    {
        public ObservableCollection<CameraViewModel> Cameras { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private CameraViewModel selectedCamera;
        public INavigation Navigation { get; set; }

        public CamerasListViewModel()
        {
            //TODO: сделать camera dto и получить в него данные с xml api сайта
            Cameras = new ObservableCollection<CameraViewModel>();
        }

        public CameraViewModel SelectedCamera
        {
            get => selectedCamera;
            set
            {
                if (selectedCamera != value)
                {
                    CameraViewModel tempCamera = value;
                    selectedCamera = null;
                    OnPropertyChanged("SelectedCamera");
                    Navigation.PushAsync(new CameraPage(tempCamera));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
