using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AttractionsList : List<Attractions>
    {
        public AttractionsList() { }
        public AttractionsList(IEnumerable<Attractions> list) : base(list) { }
        public AttractionsList(IEnumerable<BaseEntity> list) : base(list.Cast<Attractions>().ToList()) { }
    }
}
