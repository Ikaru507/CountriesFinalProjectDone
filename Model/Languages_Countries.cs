using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Languages_Countries : BaseEntity
    {
        private int countryId;
        private int languageId;

        public int CountryId { get => countryId; set => countryId = value; }
        public int LanguageId { get => languageId; set => languageId = value; }
    }
}
