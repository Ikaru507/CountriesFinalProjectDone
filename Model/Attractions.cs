using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Attractions:BaseEntity
    {
        private string attractionName;
        private Countries country;
        private Category category;
        private string description;

        public string AttractionName { get => attractionName; set => attractionName = value; }
        public Countries Country { get => country; set => country = value; }
        public Category Category { get => category; set => category = value; }
        public string Description { get => description; set => description = value; }
    }
}
