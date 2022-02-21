using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ViewModel.Generic
{
    public class PageResult<T>:Result<List<T>> where T : class
    {
        public int Page { get; set; }

        public int ResultCount { get; set; }

        public int ResultsPerpage { get; set; }
    }
}
