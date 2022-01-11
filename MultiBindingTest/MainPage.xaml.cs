using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MultiBindingTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ListPage("B"));

        }

        private void AButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ListPage("A"));
        }
    }
}
