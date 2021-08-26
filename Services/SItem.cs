using CustomerSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSales.Services
{
    public class SItem : IItem
    {
        CustomerSalesDBContext db = null;
        public SItem(CustomerSalesDBContext context)
        {
            db = context;
        }
        public EItem Add(EItem item)    
        {
            db.Add(item);
            db.SaveChanges();
            return item;
        }

        public bool Delete(int id)
        {
            var model = GetItemById(id);
            if (model == null) {
                return false;
            }
            db.Remove(model);
            db.SaveChanges();
            return true;
        }

        public EItem GetItemById(int id)
        {
            return GetItems().FirstOrDefault(x => x.Id == id);
        }

        public List<EItem> GetItems()
        {
            return db.EItems.ToList();
        }

        public EItem Update(EItem item)
        {
            db.Update(item);
            db.SaveChanges();
            return item;
        }
    }
    public interface IItem {
        List<EItem> GetItems();
        EItem GetItemById(int id);
        EItem Add(EItem item);
        EItem Update(EItem item);

        bool Delete(int id);
    }
}
