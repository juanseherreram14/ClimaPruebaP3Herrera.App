using ClimaPruebaP3Herrera.Data;
namespace ClimaPruebaP3Herrera;

public partial class App : Application
{
    private static WeatherDB _database;

    public static WeatherDB Database
    {
        get
        {
            if (_database == null)
            {
                _database = new WeatherDB(Path.Combine(FileSystem.AppDataDirectory, "weather.db"));
            }
            return _database;
        }
    }
    public App()
    {
        InitializeComponent();
        
        MainPage = new WelcomePage();
    }
}
