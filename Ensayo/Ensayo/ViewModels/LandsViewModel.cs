namespace Ensayo.ViewModels
{
    using Ensayo.Models;
    using Ensayo.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Linq;

    class LandsViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<RootObjectItemViewModel> lands; //LISTA DE OBJETOS OBSERVAC PARA QUE SE REFRESQUE LISTVIEW DE MODELS
        private bool isRefreshing;
        private string filter;
        private List<RootObject> landslist;
        #endregion

        #region Properties
        public ObservableCollection<RootObjectItemViewModel> Lands
        {
            get
            {
                return this.lands;
            }
            set
            {
                SetValue(ref this.lands, value);
            }
        }
        public bool IsRefreshing //CUANDO LA APLICACION ESTE CARGANDO, PARA CARGAR LA LISTA
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
        public string Filter //CUANDO LA APLICACION ESTE CARGANDO, PARA CARGAR LA LISTA
        {
            get
            {
                return this.filter;
            }
            set
            {
                SetValue(ref this.filter, value);
                this.Search(); //FILTRO QUE BUSQUE DIRECTAMENTE SE DIGITE ALGO
            }
        }
   
        #endregion

        #region Constructors
        public LandsViewModel()
        {
            this.apiservice = new ApiService();
            this.LoadLands();//INICIAR METODO LOADLANDS
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
                await Application.Current.MainPage.Navigation.PopAsync();//DESAPILAR LA NAVEGACION, FLECHA DE PARA ATRAS, DEVOLVER
                return;
            }

            //CONSUME API
            var response = await this.apiservice.GetList<RootObject>("http://restcountries.eu", "/rest", "/v2/all");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                await Application.Current.MainPage.Navigation.PopAsync();//DESAPILAR LA NAVEGACION, FLECHA DE PARA ATRAS, DEVOLVER
                return;
            }

            this.landslist = (List<RootObject>) response.Result;
            this.Lands = new ObservableCollection<RootObjectItemViewModel>(this.ToRootObjectItemViewModel());//OBJETO EN MEMORIA
            this.IsRefreshing = false;
        }

        private IEnumerable<RootObjectItemViewModel> ToRootObjectItemViewModel()
        {
            return this.landslist.Select(l => new RootObjectItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                //TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });
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
                return new RelayCommand(LoadLands);//CUANDO SE HAGA TAP VA A EL METODO ASYNC LoadLands
            }
        }
        public ICommand SearchCommand //CUANDO LA APLICACION ESTE CARGANDO, PARA CARGAR LA LISTA
        {
            get
            {
                return new RelayCommand(Search);//CUANDO SE HAGA TAP VA A EL METODO ASYNC LoadLands
            }
        }

        private void Search()
        {
            if(string.IsNullOrEmpty(this.Filter))
            {
                this.Lands = new ObservableCollection<RootObjectItemViewModel>(this.ToRootObjectItemViewModel());//OBJETO EN MEMORIA
            }
            else
            {
                this.Lands = new ObservableCollection<RootObjectItemViewModel>(this.ToRootObjectItemViewModel().Where(
                    l => l.Name.ToLower().Contains(this.Filter.ToLower()) ||
                         l.Capital.ToLower().Contains(this.Filter.ToLower())
                ));//para busqueda LINQ
            }
        }
        #endregion
    }
}
