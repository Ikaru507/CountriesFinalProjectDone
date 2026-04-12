using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VisitedCountries : BaseEntity
    {
        private int userId;
        private int countryId;
        private DateTime dateVisited;

        public int UserId { get => userId; set => userId = value; }
        public int CountryId { get => countryId; set => countryId = value; }
        public DateTime DateVisited { get => dateVisited; set => dateVisited = value; }
    }
}
