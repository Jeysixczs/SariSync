using SariSariStore.Admin.View.Interface;
using SariSariStore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SariSariStore.Admin.Presenter
{
    public class MainFormPresenter
    {
        public IMainForm imainForm;


        public MainFormPresenter(IMainForm imainForm)
        {
            this.imainForm = imainForm;
        }

        // Method to load products
        public void LoadProducts()
        {
            imainForm.LoadProducts();
        }
        // Method to load orders
        public void LoadOrders()
        {
            imainForm.LoadOrders();
        }


    }
}
