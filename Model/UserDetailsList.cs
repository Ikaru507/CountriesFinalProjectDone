using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserDetailsList : List<UserDetails>
    {
        public UserDetailsList() { }
        public UserDetailsList(IEnumerable<UserDetails> list) : base(list) { }
        public UserDetailsList(IEnumerable<BaseEntity> list) : base(list.Cast<UserDetails>().ToList()) { }
    }
}
