using CustomerSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSales.Services
{
    public class SCustomer : ICustomer
    {
        CustomerSalesDBContext db = null;
        public SCustomer(CustomerSalesDBContext context) {
            db = context;
        }
        public ECustomer Add(ECustomer eCustomer)
        {
            db.Add(eCustomer);
            db.SaveChanges();
            return eCustomer;
        }

        public ECustomer Update(ECustomer eCustomer) {
            db.Update(eCustomer);
            db.SaveChanges();
            return eCustomer;
        }

        public bool Delete(int id)
        {
            var model = GetCustomerById(id);
            if (model == null) {
                return false;
            }
            db.Remove(model);
            db.SaveChanges();
            return true;
        }

        public ECustomer GetCustomerById(int id)
        {
            return GetCustomers().FirstOrDefault(x => x.Id == id);
        }

        public List<ECustomer> GetCustomers()
        {
            return db.ECustomers.ToList();
        }
    }

    public interface ICustomer {
        List<ECustomer> GetCustomers();
        ECustomer GetCustomerById(int id);
        ECustomer Add(ECustomer eCustomer);
        ECustomer Update(ECustomer eCustomer);

        bool Delete(int id);

    }
}
