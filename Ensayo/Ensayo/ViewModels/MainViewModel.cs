namespace Ensayo.ViewModels
{
    class MainViewModel
    {
        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }

        public LandsViewModel Lands //OBJETO PARA BINDING DESDE XAML
        {
            get;
            set;
        }

        public LandViewModel Land //OBJETO PARA BINDING DESDE XAML
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
        #endregion

        //Permite hacer un llamado de la MainViewModel desde cualquier clase, sin necesidad de tener que instanciar otra
        #region Singleton 
        private static MainViewModel instance;

        public static MainViewModel GetInstance()//PARA QUE DEVUELVA UNA INSTANCIA
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
