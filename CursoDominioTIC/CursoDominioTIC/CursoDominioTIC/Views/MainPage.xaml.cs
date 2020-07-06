﻿using CursoDominioTIC.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CursoDominioTIC.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnStack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new StackLayoutPage());
        }

        private void btnGrid_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new GridPage());
        }
    }
}
