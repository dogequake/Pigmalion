namespace Pigmalion.Models
{
    public class DataViewModel
    {
        List<Client> Listclients = new List<Client>();
        List<Country> Listcountry = new List<Country>();
        List<City> Listcity = new List<City>();
        List<Region> Listregion = new List<Region>();
        List<Direction> Listdirection = new List<Direction>();
        public DataViewModel(List<Client> clients,
            List<Country> countries,
            List<City> cities,
            List<Region> regions,
            List<Direction> directions) 
        {
            Listclients = clients;

            Listcountry= countries;

            Listcity= cities;

            Listdirection=directions;

            Listregion = regions;
        }
    }
}
