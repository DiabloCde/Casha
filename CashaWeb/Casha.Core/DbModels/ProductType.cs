using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.Core.DbModels
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }

        public string TypeName { get; set; }

        public List<Product> Products { get; set; }
    }
}
