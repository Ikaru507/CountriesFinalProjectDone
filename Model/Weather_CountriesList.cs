using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Weather_CountriesList : List<Weather_Countries>
    {
        public Weather_CountriesList() { }
        public Weather_CountriesList(IEnumerable<Weather_Countries> list) : base(list) { }
        public Weather_CountriesList(IEnumerable<BaseEntity> list) : base(list.Cast<Weather_Countries>().ToList()) { }
    }
}
