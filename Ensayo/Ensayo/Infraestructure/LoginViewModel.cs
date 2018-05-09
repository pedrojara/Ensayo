namespace Ensayo.ViewModels
{
    using System.Windows.Input;
    using Xamarin.Forms;
    using GalaSoft.MvvmLight.Command;

    class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string nid;
        private string contrasena;
        private bool isRunning;
        private bool isEnabled;
        
        private bool refreshCommand;
        #endregion


        #region Properties
        public string Nid
        {
            get
            {
                return this.nid;
            }
            set
            {
                SetValue(ref this.nid, value);
            }
        }
        public string Contrasena
        {
            get
            {
                return this.contrasena;
            }
            set
            {
                SetValue(ref this.contrasena, value);
            }
        }
        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }
            set
            {
                SetValue(ref this.isRunning, value);
            }
        }
        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }
            set
            {
                SetValue(ref this.isEnabled, value);
            }
        }
       
        #endregion



        #region Constructors
        public LoginViewModel()
        {
            this.IsEnabled = true;
            //http://restcountries.eu/rest/v2/all
        }

        public async void Login()
        {
            if (string.IsNullOrEmpty(this.Nid))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debe ingresar el Número de Documento", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Contrasena))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debe ingresar la Contraseña", "Aceptar");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            /*
            if (this.Nid != "123456" || this.Contrasena != "1111")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error", "Número de Documento o Contraseña Erroneos", "Aceptar");
                this.Contrasena = string.Empty;
                return;
            }
            else
            {
                this.IsRunning = true;
                this.IsEnabled = false;
                await Application.Current.MainPage.DisplayAlert("Información", "Desea Continuar?", "Cancelar", "Aceptar");
                return;
            }*/

            this.Nid = string.Empty;
            this.Contrasena = string.Empty;

            MainViewModel.GetInstance().Lands = new LandsViewModel();
            //SE APILA PARA NAVEGAR
            //await Application.Current.MainPage.Navigation.PushAsync(new LandsPage1());

        }
        #endregion


        #region Commands
        public ICommand IngresarCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }


        public ICommand ResgistrarmeCommand
        {
            get;
            set;
        }
        public ICommand OlvideClaveCommand
        {
            get;
            set;
        }
        #endregion


    }
}
