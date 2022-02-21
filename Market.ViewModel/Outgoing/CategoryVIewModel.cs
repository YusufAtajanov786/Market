using Market.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ViewModel
{
    public class CategoryVIewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


        public static explicit operator CategoryVIewModel(Category v)
        {
            return new CategoryVIewModel { Id = v.Id, Name = v.Name };
        }

       
    }
}
