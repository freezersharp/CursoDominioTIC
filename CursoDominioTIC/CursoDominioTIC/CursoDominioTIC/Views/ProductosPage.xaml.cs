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
    public partial class ProductosPage : ContentPage
    {
        public ProductosPage(Establecimiento establecimiento)
        {
            InitializeComponent();
            Title = $"Productos de {establecimiento.Nombre}";
        }
    }
}