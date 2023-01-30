using ClimaPruebaP3Herrera.Models;
using ClimaPruebaP3Herrera.Data;
using System.Collections.ObjectModel;
using SQLite;

namespace ClimaPruebaP3Herrera;


public partial class CityDataPage : ContentPage
{
    

    public CityDataPage()
    {
        InitializeComponent();
        List<CityData> city = App.Database.GetAllCities();
        cityList.ItemsSource = city;

    }
    private void OnVolverClicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new WeatherPage());
    }
}