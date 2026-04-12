using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CountriesList : List<Countries>
    {
        public CountriesList() { }
        public CountriesList(IEnumerable<Countries> list) : base(list) { }
        public CountriesList(IEnumerable<BaseEntity> list) : base(list.Cast<Countries>().ToList()) { }
    }
}
