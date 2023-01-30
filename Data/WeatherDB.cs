
using ClimaPruebaP3Herrera.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ClimaPruebaP3Herrera.Data
{
    public class WeatherDB 
    {
        string _dbPath;
        private SQLiteConnection conn;
        public WeatherDB(string DatabasePath)
        {
            _dbPath = DatabasePath;
        }
        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<CityData>();
        }
        public int AddNewCity(CityData city)
        {
            Init();
            int result = conn.Insert(city);
            return result;
        }
        public List<CityData> GetAllCities()
        {
            Init();
            List<CityData> cities = conn.Table<CityData>().ToList();
            return cities;
        }



    }

}
