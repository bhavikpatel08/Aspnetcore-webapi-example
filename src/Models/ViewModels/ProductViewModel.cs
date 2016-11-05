using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreWebAPI.Models.ViewModels
{
    public class ProductViewModel
    {
        public int? ProductID { get; set; }

        public string ProductName { get; set; }

        public string ProductNumber { get; set; }
    }
}
