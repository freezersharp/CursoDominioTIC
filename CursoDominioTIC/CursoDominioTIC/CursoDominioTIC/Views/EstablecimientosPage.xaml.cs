using CursoDominioTIC.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CursoDominioTIC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EstablecimientosPage : ContentPage
    {
        public EstablecimientosPage()
        {
            InitializeComponent();
        }

        private void lst_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var estab = e.Item as Establecimiento;
            if(estab != null)
            {
                Navigation.PushAsync(new ProductosPage(estab));
                lst.SelectedItem = null;
            }
        }
    }
}