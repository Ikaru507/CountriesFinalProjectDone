using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Languages:BaseEntity
    {
        private string languageName;

        public string LanguageName { get => languageName; set => languageName = value; }
    }
}
