using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Weather_Countries : BaseEntity
    {
        private int countryId;
        private int weatherId;

        public int CountryId { get => countryId; set => countryId = value; }
        public int WeatherId { get => weatherId; set => weatherId = value; }
    }
}
