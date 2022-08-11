namespace SuperHeroAPI.Models
{
    public class SuperHeroResponse
    {
        public List<SuperHero> SuperHeroes { get; set; }
        public int? Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
