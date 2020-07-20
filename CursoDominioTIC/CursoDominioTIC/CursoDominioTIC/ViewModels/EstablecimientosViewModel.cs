using CursoDominioTIC.Common.Models;
using System.Collections.ObjectModel;

namespace CursoDominioTIC.ViewModels
{
    public class EstablecimientosViewModel : BaseViewModel
    {
        private ObservableCollection<Establecimiento> establecimientos;
        public ObservableCollection<Establecimiento> Establecimientos
        {
            get => this.establecimientos;
            set => this.SetValue(ref this.establecimientos, value);
        }
        public EstablecimientosViewModel()
        {
            Establecimientos = new ObservableCollection<Establecimiento>
            {
                new Establecimiento
                {
                    IdEstablecimiento = 1,
                    Nombre = "Wendy's",
                    Calificacion = 4,
                    Descripcion = "Hamburguesas Wendy's"
                },
                new Establecimiento
                {
                    IdEstablecimiento = 2,
                    Nombre = "McDonald's",
                    Calificacion = 5,
                    Descripcion = "Hamburguesas McDonald's"
                },
                new Establecimiento
                {
                    IdEstablecimiento = 3,
                    Nombre = "Burger King",
                    Calificacion = 4,
                    Descripcion = "Hamburguesas Burger King"
                },
            };
        }
    }
}
