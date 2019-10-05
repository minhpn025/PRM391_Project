using CoffeeManagement.Models;
using PagedList;

namespace CoffeeManagement.ViewModels
{
    public class ManageProductViewModels
    {
        public IPagedList<Product> Products { get; set; }
    }
}