namespace Ensayo.ViewModels
{
    using Ensayo.Models;
    using Ensayo.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;

    class LandsViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<RootObject> lands;
        private bool isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<RootObject> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }
        public bool IsRefreshing
        {
            get
            {
                return this.isRefreshing;
            }
            set
            {
                SetValue(ref this.isRefreshing, value);
            }
        }
        #endregion

        #region Constructors
        public LandsViewModel()
        {
            this.apiservice = new ApiService();
            this.LoadLands();
        }
        #endregion

        #region Methods
        private async void LoadLands()
        {
            this.IsRefreshing = true; //Para cargar la lista
            //VERIFICAR SI HAY CONEXION
            var conection = await this.apiservice.CheckConnection();
            if (!conection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", conection.Message, "Aceptar");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            //CONSUME API
            var response = await this.apiservice.GetList<RootObject>(
                "http://restcountries.eu", 
                "/rest", 
                "/v2/all");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            var list = (List<RootObject>) response.Result;
            this.Lands = new ObservableCollection<RootObject>(list);
            this.IsRefreshing = false;
        }
        #endregion

        #region Services
        private ApiService apiservice;
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadLands);
            }
        }
        #endregion
    }
}
