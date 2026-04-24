using HeroEngine.Core.Data;
using HeroEngine.Core.Models;
using System.Text.Json;

namespace HeroEngine.Core.Data
{
    public class HeroRepository
    {
        private string path;

        public HeroRepository()
        {
            string webPath = "Data/heroes.json";
            string corePath = "../../../../HeroEngine.Web/Data/heroes.json";

            if (File.Exists(webPath))
            {
                path = webPath;
            }
            else
            {
                path = corePath;
            }
        }

        public List<AHero> LoadAll()
        {
            return JsonManager.Read<AHero>(path);
        }

        public void SaveAll(IEnumerable<AHero> heroes)
        {
            JsonManager.Write(path, heroes.ToList());
        }

        public void Add(AHero hero)
        {
            List<AHero> heroes = LoadAll();
            heroes.Add(hero);
            SaveAll(heroes);
        }

        public void Delete(string name)
        {
            List<AHero> heroes = LoadAll();
            var heroDelete = heroes.FirstOrDefault(h => h.Name.ToLower() == name.ToLower());
            if (heroDelete != null)
            {
                heroes.Remove(heroDelete);
                JsonManager.Write(path, heroes);
            }
        }
    }
}