using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WeatherList : List<Weather>
    {
        public WeatherList() { }
        public WeatherList(IEnumerable<Weather> list) : base(list) { }
        public WeatherList(IEnumerable<BaseEntity> list) : base(list.Cast<Weather>().ToList()) { }
    }
}
