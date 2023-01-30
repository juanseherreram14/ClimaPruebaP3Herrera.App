
using ClimaPruebaP3Herrera.Services;
using ClimaPruebaP3Herrera.Models;
using ClimaPruebaP3Herrera.Data;
namespace ClimaPruebaP3Herrera;

public partial class WeatherPage : ContentPage
{
    public List<Models.List> WeatherList;
    private double latitude;
    private double longitude;
    public WeatherPage()
    {
        InitializeComponent();
        WeatherList = new List<Models.List>();
      
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await GetLocation();
        var result = await APIService.GetWeather(latitude,longitude);
        foreach(var item in result.list)
        {
            WeatherList.Add(item);
        }
        CvClima.ItemsSource = WeatherList;
        LblCiudad.Text = result.city.name;
        LblDescripcion.Text = result.list[0].weather[0].description;
        LblTemperatura.Text = result.list[0].main.temperatura + "°C";
        LblHumedad.Text =  result.list[0].main.humidity + "%";
        LblViento.Text = result.list[0].wind.speed + "km/h";
        IconoClima.Source = result.list[0].weather[0].customIcon;
    }

    public async Task GetLocation() {
        Location location = await Geolocation.GetLastKnownLocationAsync();
        latitude = location.Latitude;
        longitude = location.Longitude;

    }

    private async void TapLocation_Tapped(object sender, EventArgs e)
    {
        await GetLocation();
        await GetWeatherDataByLocation(latitude,longitude);
    }

    public async Task GetWeatherDataByLocation(double latitude, double longitude) {
        var result = await APIService.GetWeather(latitude, longitude);
        UpdateUi(result);        
    }



    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        
        var response = await DisplayPromptAsync(title: "", message: "", placeholder: "Buscar Clima por ciudad", accept: "Buscar", cancel: "Cancelar");
        var result = await APIService.GetWeatherByCity(response);
        if (response != null)
        {
            await GetWeatherDataByCity(response);
            App.Database.AddNewCity(new CityData
            {
                Name = response,
                WeatherData = result.list[0].main.temperatura + "°C"
            });
        }
    }



    public async Task GetWeatherDataByCity(string city)
    {
        var result = await APIService.GetWeatherByCity(city);
        UpdateUi(result);
    }

    public void UpdateUi(dynamic result)
    {
        foreach (var item in result.list)
        {
            WeatherList.Add(item);
        }
        CvClima.ItemsSource = WeatherList;
        LblCiudad.Text = result.city.name;
        LblDescripcion.Text = result.list[0].weather[0].description;
        LblTemperatura.Text = result.list[0].main.temperatura + "°C";
        LblHumedad.Text = result.list[0].main.humidity + "%";
        LblViento.Text = result.list[0].wind.speed + "km/h";
        IconoClima.Source = result.list[0].weather[0].customIcon;
    }

    private void History_Tapped(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new CityDataPage());
    }
}