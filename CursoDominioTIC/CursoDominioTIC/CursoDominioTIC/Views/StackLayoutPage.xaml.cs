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
    public partial class StackLayoutPage : ContentPage
    {
        public StackLayoutPage()
        {
            InitializeComponent();
        }

        private void btnRegre_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}