using CustomerSales.Interface;
using CustomerSales.Models;
using CustomerSales.Services;
using CustomerSales.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSales.Manager
{
    public class CustomerSalesManager : ICustomerSales
    {
        CustomerSalesDBContext db = null;
        SCustomer sCustomer = null;
        SItem sItem = null;
        SSales sSales = null;

        public CustomerSalesManager(CustomerSalesDBContext context)
        {
            db = context;
            sCustomer = new SCustomer(db);
            sItem = new SItem(db);
            sSales = new SSales(db);
        }

        #region customer
        private ECustomer ParseIntoModel(CustomerViewModel vm)
        {
            ECustomer eCustomer = new ECustomer()
            {
                Id = vm.Id,
                CustomerName = vm.CustomerName,
                CustomerAddress = vm.CustomerAddress,
                ContactNumber = vm.ContactNumber
            };
            return eCustomer;
        }
        public CustomerViewModel AddCustomer(CustomerViewModel customerViewModel)
        {
            var model = ParseIntoModel(customerViewModel);
            sCustomer.Add(model);
            return customerViewModel;
        }

        public bool DeleteCustomer(int id)
        {
            return sCustomer.Delete(id);
        }

        public CustomerViewModel GetCustomerById(int id)
        {
            return GetCustomers().FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerViewModel> GetCustomers()
        {
            return (from c in sCustomer.GetCustomers()
                    select new CustomerViewModel()
                    {
                        Id = c.Id,
                        ContactNumber = c.ContactNumber,
                        CustomerAddress = c.CustomerAddress,
                        CustomerName = c.CustomerName
                    }).ToList();
        }

        public CustomerViewModel UpdateCustomer(CustomerViewModel customerViewModel)
        {
            var model = ParseIntoModel(customerViewModel);
            sCustomer.Update(model);
            return customerViewModel;
        }

        #endregion

        #region Item
        private EItem ParseIntoModel(ItemViewModel itemViewModel)
        {
            EItem eItem = new EItem()
            {
                Id = itemViewModel.Id,
                ItemName = itemViewModel.ItemName,
                ItemTotal = itemViewModel.ItemTotal,
                ItemDescription = itemViewModel.ItemDescription,
                ItemQuantity = itemViewModel.ItemQuantity,
                ItemRate = itemViewModel.ItemRate,
                ItemRateDescription = itemViewModel.ItemRateDescription
            };
            return eItem;
        }
        public List<ItemViewModel> GetItem()
        {
            return (from c in sItem.GetItems()
                    select new ItemViewModel()
                    {
                        Id = c.Id,
                        ItemDescription = c.ItemDescription,
                        ItemName = c.ItemName,
                        ItemQuantity = c.ItemQuantity,
                        ItemRate = c.ItemRate,
                        ItemRateDescription = c.ItemRateDescription,
                        ItemTotal = c.ItemTotal
                    }).ToList();
        }

        public ItemViewModel GetItemById(int id)
        {
            return GetItem().FirstOrDefault(s => s.Id == id);
        }

        public ItemViewModel AddItem(ItemViewModel itemViewModel)
        {
            var items = ParseIntoModel(itemViewModel);
            sItem.Add(items);
            return itemViewModel;

        }

        public ItemViewModel UpdateItem(ItemViewModel itemViewModel)
        {
            var items = ParseIntoModel(itemViewModel);
            sItem.Update(items);
            return itemViewModel;
        }

        public bool DeleteItem(int id)
        {
            return sItem.Delete(id);
        }

        #endregion
        #region Sales
        public List<SalesViewModel> GetSales()
        {
            var sales = sSales.GetSales();
            var result = (from c in sales
                          select new SalesViewModel()
                          {
                              Master = new SalesMasterViewModel()
                              {
                                  Id = c.Id,
                                  Discount = c.Discount,
                                  IsDeleted = c.IsDeleted,
                                  NetAmount = c.NetAmount,
                                  SalesDate = c.SalesDate.ToString("yyyy/MM/dd"),
                                  SalesNo = c.SalesNo,
                                  TotalSales = c.TotalSales
                              },
                              Details = GetSalesDetails(c.Id)
                          }).ToList();
            return result;
        }

        private List<SalesDetailViewModel> GetSalesDetails(int masterId)
        {
            var salesDetails = sSales.GetSalesDetails(masterId);
            var result = (from c in salesDetails
                          select new SalesDetailViewModel()
                          {
                              Id = c.Id,
                              IsDeleted = c.IsDeleted,
                              ItemId = c.ItemId,
                              CustomerId = c.CustomerId,
                              Quantity = c.Quantity,
                              Rate = c.Rate,
                              SalesId = c.SalesId,
                              Total = c.Total
                          }).ToList();
            return result;
        }

        public SalesViewModel GetSalesById(int masterId)
        {
            var sales = GetSales().Where(x => x.Master.Id == masterId).FirstOrDefault();
            return sales;
        }

        public void AddSalesAndDetails(SalesViewModel vm)
        {
            ESales esales = BindSaleVmIntoModel(vm.Master);
            var master = sSales.Add(esales).Data;
            List<ESalesDetail> eSalesDetail = BindSalesDetailsVmIntoModel(vm.Details, master.Id);
            sSales.AddSaleDetails(eSalesDetail);
        }

        private List<ESalesDetail> BindSalesDetailsVmIntoModel(List<SalesDetailViewModel> details, int masterId)
        {
            var result = (from c in details
                          select new ESalesDetail()
                          {
                              Id = c.Id,
                              IsDeleted = false,
                              ItemId = c.ItemId,
                              CustomerId = c.CustomerId,
                              Quantity = c.Quantity,
                              Rate = c.Rate,
                              SalesId = masterId,
                              Total = c.Total
                          }).ToList();
            return result;
        }

        private ESales BindSaleVmIntoModel(SalesMasterViewModel vm)
        {
            return new ESales()
            {
                Id = vm.Id,
                Discount = vm.Discount,
                IsDeleted = false,
                NetAmount = vm.NetAmount,
                SalesDate = DateTime.Now,
                SalesNo = vm.SalesNo,
                TotalSales = vm.TotalSales,
            };
        }

        public void UpdateSalesAndDetails(SalesViewModel vm)
        {
            ESales esales = BindSaleVmIntoModel(vm.Master);
            sSales.Update(esales);

            var existingDetails = sSales.GetSalesDetails(vm.Master.Id).ToList();
            sSales.DeleteSalesDetails(existingDetails);

            List<ESalesDetail> eSalesDetail = BindSalesDetailsVmIntoModel(vm.Details, vm.Master.Id);
            sSales.AddSaleDetails(eSalesDetail);
        }

        public void DeleteSale(int masterId)
        {
            sSales.Delete(masterId);
        }
        #endregion
    }
}
