namespace Ensayo.ViewModels
{
    using Ensayo.Models;
    public class LandViewModel
    {
        #region Propperties
        public RootObject Land
        {
            get;
            set;
        }
        #endregion


        #region Constructor
        public LandViewModel(RootObject land)
        {
            this.Land = land;
        } 
        #endregion
    }
}
