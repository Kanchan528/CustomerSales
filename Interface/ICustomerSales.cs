using CustomerSales.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSales.Interface
{
    interface ICustomerSales
    {
        #region Customer
        List<CustomerViewModel> GetCustomers();
        CustomerViewModel GetCustomerById(int id);
        CustomerViewModel AddCustomer(CustomerViewModel customerViewModel);
        CustomerViewModel UpdateCustomer(CustomerViewModel customerViewModel);
        bool DeleteCustomer(int id);
        #endregion

        #region Item
        List<ItemViewModel> GetItem();
        ItemViewModel GetItemById(int id);
        ItemViewModel AddItem(ItemViewModel itemViewModel);
        ItemViewModel UpdateItem(ItemViewModel itemViewModel);
        bool DeleteItem(int id);

        #endregion

        #region Sales
        List<SalesViewModel> GetSales();
        SalesViewModel GetSalesById(int masterId);
        void AddSalesAndDetails(SalesViewModel vm);
        void UpdateSalesAndDetails(SalesViewModel vm);
        void DeleteSale(int masterId);
        #endregion
    }
}
