using Market.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markek.Service.Services.IService
{
    public interface IProductService
    {
        ProductViewModel GetProductById(Guid id);
    }
}
