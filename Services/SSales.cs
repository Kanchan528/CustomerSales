using CustomerSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSales.Services
{
    public class SSales : ISales
    {
        CustomerSalesDBContext db = null;
        public SSales(CustomerSalesDBContext context)
        {
            db = context;
        }

        public ServiceResult<ESales> Add(ESales eSales)
        {
            db.Add(eSales);
            db.SaveChanges();
            return new ServiceResult<ESales>()
            {
                Data = eSales,
                Message = "Added successfully",
                ResultStatus = ResultStatus.Ok
            };
        }
        public bool Delete(int id)
        {
            var item = GetSalesById(id);
            if (item == null)
            {
                return false;
            }
            db.Remove(item);
            db.SaveChanges();
            return true;
        }
        public List<ESales> GetSales()
        {
            return db.ESales.ToList();
        }
        public ESales GetSalesById(int id)
        {
            return GetSales().FirstOrDefault(x => x.Id == id);
        }

        public void AddSaleDetails(List<ESalesDetail> eSalesDetails)
        {
            db.AddRange(eSalesDetails);
            db.SaveChanges();
        }

        public void DeleteSalesDetails(List<ESalesDetail> eSalesDetails)
        {
            db.RemoveRange(eSalesDetails);
            db.SaveChanges();
        }
        public IQueryable<ESalesDetail> GetSalesDetails(int masterId)
        {
            return db.ESalesDetails.Where(x => x.SalesId == masterId);
        }

        public ESales Update(ESales eSales)
        {
            db.Update(eSales);
            db.SaveChanges();
            return eSales;
        }
    }
    public interface ISales
    {
        List<ESales> GetSales();
        ESales GetSalesById(int id);
        ServiceResult<ESales> Add(ESales eSales);
        ESales Update(ESales eSales);
        bool Delete(int id);

        IQueryable<ESalesDetail> GetSalesDetails(int masterId);
        void AddSaleDetails(List<ESalesDetail> eSalesDetails);
        void DeleteSalesDetails(List<ESalesDetail> eSalesDetails);
    }

}
