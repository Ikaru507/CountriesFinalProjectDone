using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VisitedCountriesList : List<VisitedCountries>
    {
        public VisitedCountriesList() { }
        public VisitedCountriesList(IEnumerable<VisitedCountries> list) : base(list) { }
        public VisitedCountriesList(IEnumerable<BaseEntity> list) : base(list.Cast<VisitedCountries>().ToList()) { }
    }
}
