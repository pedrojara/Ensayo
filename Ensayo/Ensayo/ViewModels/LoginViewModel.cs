namespace Ensayo.ViewModels
{
    using System.Windows.Input;
    using Xamarin.Forms;
    using GalaSoft.MvvmLight.Command;
    using Ensayo.Views;

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
        //REFRESQUE LA VISTA
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
        public bool IsRunning //ActivityIndicator
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
        public bool IsEnabled //HABILITAR LOS BOTONES
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
            this.IsEnabled = true; //INICIALIZAR SE MUESTRA ACTIVO EL BOTON
        }

        public async void Login()
        {
            if (string.IsNullOrEmpty(this.Nid))//SE VALIDA SI EL USUARIO DIGITO EL NID
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
                this.IsRunning = false;
                this.IsEnabled = true;
                this.Nid = string.Empty;
                this.Contrasena = string.Empty;
                
                // await Application.Current.MainPage.DisplayAlert("Información", "Desea Continuar?", "Cancelar", "Aceptar");
                var action = await Application.Current.MainPage.DisplayAlert("Información", "Desea Continuar?", "Aceptar", "Cancelar");

                if (action)
                {
                    this.Nid = string.Empty;
                    this.Contrasena = string.Empty;
                    MainViewModel.GetInstance().Lands = new LandsViewModel();//SE INSTANCIA LA VIEWMODEL DE LA PAGE POR PATRON SINGLETON PARA NO INSTANCIAR MAS
                    await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());//SE APILA PARA NAVEGAR
                }
                return;
            }
        }
        #endregion


        #region Commands
        //ACCION DE LOS BOTONES
        public ICommand IngresarCommand
        {
            get
            {
                return new RelayCommand(Login);//CUANDO SE HAGA TAP VA A EL METODO ASYNC LOGIN
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
