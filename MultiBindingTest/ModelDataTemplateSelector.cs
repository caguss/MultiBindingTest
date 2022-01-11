using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MultiBindingTest
{
    public class ModelDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AModelTemplate { get; set; }
        public DataTemplate BModelTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            try
            {
                ////you can use this!
                //switch (item.GetType().ToString())
                //{
                //    case "AModel":
                //        return AModelTemplate;
                //    case "BModel":
                //        return BModelTemplate;
                //}

                return ((AModel)item).Title == null ? AModelTemplate : BModelTemplate; 
            }
            catch (Exception)
            {
                return BModelTemplate;
            }
        }
    }
}
