using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LanguagesList : List<Languages>
    {
        public LanguagesList() { }
        public LanguagesList(IEnumerable<Languages> list) : base(list) { }
        public LanguagesList(IEnumerable<BaseEntity> list) : base(list.Cast<Languages>().ToList()) { }
    }
}
