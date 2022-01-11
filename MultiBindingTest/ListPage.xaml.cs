using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MultiBindingTest
{
    public partial class ListPage : ContentPage
    {
        ListViewModel model;
        public ListPage()
        {
            InitializeComponent();
        }
        public ListPage(string type)
        {
            InitializeComponent();
            switch (type)
            {
                case "A":
                    BindingContext = model = new ListViewModel("A");
                    ItemsListView.ItemsSource = model.AItems;
                    break;
                case "B":
                    BindingContext = model = new ListViewModel("B");
                    ItemsListView.ItemsSource = model.BItems;

                    break;
            }
        }
    }
}
