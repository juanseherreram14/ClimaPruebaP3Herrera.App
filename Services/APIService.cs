using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ClimaPruebaP3Herrera.Models;

namespace ClimaPruebaP3Herrera.Services
{
    public static class APIService
    {
        public static async Task<Root> GetWeather(double latitud, double longitud) 
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("http://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&units=metric&appid=c2ad28d92fdcb8ce8084c7711a5945b3",latitud,longitud));
            return JsonConvert.DeserializeObject<Root>(response);
        }

        public static async Task<Root> GetWeatherByCity(string ciudad)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?q={0}&units=metric&appid=c2ad28d92fdcb8ce8084c7711a5945b3", ciudad));
            return JsonConvert.DeserializeObject<Root>(response);
        }
    }
}
