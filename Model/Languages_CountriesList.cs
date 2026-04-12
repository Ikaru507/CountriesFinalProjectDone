using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Languages_CountriesList : List<Languages_Countries>
    {
        public Languages_CountriesList() { }
        public Languages_CountriesList(IEnumerable<Languages_Countries> list) : base(list) { }
        public Languages_CountriesList(IEnumerable<BaseEntity> list) : base(list.Cast<Languages_Countries>().ToList()) { }
    }
}
