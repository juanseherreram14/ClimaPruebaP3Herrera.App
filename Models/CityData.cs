using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaPruebaP3Herrera.Models
{
    public class CityData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string WeatherData { get; set; }
        public string Observacion { get; set; }
    }

}
