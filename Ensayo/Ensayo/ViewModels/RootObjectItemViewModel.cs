namespace Ensayo.ViewModels
{
    using Ensayo.Models;
    using Ensayo.Views;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class RootObjectItemViewModel : RootObject
    {
        #region
        public ICommand SelectLandCommand
        {
            get
            {
                return new RelayCommand(SelectLand);     
            }
        }

        private async void SelectLand()
        {
            MainViewModel.GetInstance().Land = new LandViewModel(this);//SE INVOCA LA MAINVIEWMODEL, SE LE ENVIA EL OBJETO LandViewModel()
            await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());//VA A LA PAGINA TABULADA
        }
        #endregion

    }
}
