using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ContinentsList : List<Continents>
    {
        public ContinentsList() { }
        public ContinentsList(IEnumerable<Continents> list) : base(list) { }
        public ContinentsList(IEnumerable<BaseEntity> list) : base(list.Cast<Continents>().ToList()) { }
    }
}
