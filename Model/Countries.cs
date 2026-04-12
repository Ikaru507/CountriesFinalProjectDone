using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Countries:BaseEntity
    {
        private string countryName;
        private Continents continent;

        public string CountryName { get => countryName; set => countryName = value; }
        public Continents Continent { get => continent; set => continent = value; }
    }
}
