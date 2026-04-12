using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserProfile:UserDetails
    {
        private string avatarImage;
        private string bio;

        public string AvatarImage { get => avatarImage; set => avatarImage = value; }
        public string Bio { get => bio; set => bio = value; }
    }
}
