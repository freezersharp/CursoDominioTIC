using CursoDominioTIC.Common.Models;
using System.Collections.ObjectModel;

namespace CursoDominioTIC.ViewModels
{
    public class ProductosViewModel : BaseViewModel
    {
        #region Propiedades
        private ObservableCollection<Producto> productos;
        public ObservableCollection<Producto> Productos
        {
            get => this.productos;
            set => this.SetValue(ref this.productos, value);
        }

        private Establecimiento establecimiento;
        public Establecimiento Establecimiento
        {
            get => this.establecimiento;
            set => this.SetValue(ref this.establecimiento, value);
        }

        #endregion


        public ProductosViewModel()
        {
            Productos = new ObservableCollection<Producto>
            {
                new Producto
                {
                    IdProducto = 1,
                    IdEstablecimiento = 1,
                    Nombre = "Jr. Melt",
                    Calificacion = 4,
                    Descripcion = "Hamburguesa Junior Melt."
                },
                new Producto
                {
                    IdProducto = 2,
                    IdEstablecimiento = 1,
                    Nombre = "1/4 Lb Single",
                    Calificacion = 5,
                    Descripcion = "Hamburguesa cuarto de libra."
                },
                new Producto
                {
                    IdProducto = 3,
                    IdEstablecimiento = 1,
                    Nombre = "1/2 Lb Single",
                    Calificacion = 5,
                    Descripcion = "Hamburguesa media libra."
                },
            };
        }
    }
}
