using Market.ViewModel.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ViewModel.Generic
{
    public class Result<T> where T : class
    {
        public T Content { get; set; }

        public Error Error { get; set; }

        public bool IsSucces => Error == null;

        public DateTime ResponseTime { get; set; } = DateTime.Now;
    }
}
