using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MultiBindingTest
{
    public class ListViewModel : BaseViewModel
    {
        private AModel _selectedAItem;
        private BModel _selectedBItem;

        public ObservableCollection<AModel> AItems { get; }
        public ObservableCollection<BModel> BItems { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<BModel> ItemTapped { get; }

        public ListViewModel()
        {
            DependencyService.Register<AModelDataStore>();
            DependencyService.Register<BModelDataStore>();
            AItems = new ObservableCollection<AModel>();
            BItems = new ObservableCollection<BModel>();
            ADataStore.GetRefresh();
            BDataStore.GetRefresh();
            ExecuteLoadItemsCommand("A");
            ExecuteLoadItemsCommand("B");
        }



        public ListViewModel(string Type)
        {
            switch (Type)
            {
                case "A":
                    Title = "AModel";
                    DependencyService.Register<AModelDataStore>();

                    AItems = new ObservableCollection<AModel>();
                    ADataStore.GetRefresh();

                    LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand("A"));
                    //AddItemCommand = new Command(OnAddItem);


                    break;
                case "B":
                    Title = "BModel";
                    DependencyService.Register<BModelDataStore>();

                    BItems = new ObservableCollection<BModel>();
                    BDataStore.GetRefresh();

                    LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand("B"));
                    //ItemTapped = new Command<BModel>(OnItemSelected);

                    break;
            }

        }

        async Task ExecuteLoadItemsCommand(string Type)
        {
            IsBusy = true;

            try
            {
                switch (Type)
                {
                    case "A":
                        AItems.Clear();
                        var aitems = await ADataStore.GetItemsAsync(true);
                        foreach (var item in aitems)
                        {
                            AItems.Add(item);
                        }
                        break;
                    case "B":
                        BItems.Clear();
                        var bitems = await BDataStore.GetItemsAsync(true);
                        foreach (var item in bitems)
                        {
                            BItems.Add(item);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {

            }

            finally
            {
                IsBusy = false;
            }
        }
    }
}
