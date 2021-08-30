using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCourse1.Models.ViewModels
{
    public class ProductUserVM
    {
        public ProductUserVM()
        {
            ProductList = new List<Product>();
        }
        public ApplicationUser ApplicationUser { get; set; }
        public IList<Product> ProductList { get; set; }
    }
}
