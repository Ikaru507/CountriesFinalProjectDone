using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Weather:BaseEntity
    {
        private string weatherName;

        public string WeatherName { get => weatherName; set => weatherName = value; }
    }
}
