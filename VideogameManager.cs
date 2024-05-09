using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public static class VideogameManager
    {
        public static bool InserisciVideogame(Videogame videogame)
        {
            bool ans = false;

            
            using GameContext context = new GameContext();
            try
            {
                context.Add(videogame);
                context.SaveChanges();
                ans = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return ans;

        }


        public static Videogame? GetVideogameFromId(int id)
        {
            Videogame? Temp = new Videogame();
            using GameContext context = new GameContext();
            try
            {
                Temp = (from v in context.Videogames
                        where v.VideogameId == id
                        select v).FirstOrDefault();

                if (Temp == null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return Temp;

        }
        public static List<Videogame>? GetVideogameFromName(string search)
        {
            List<Videogame> Temp = new List<Videogame>();
            using GameContext context = new GameContext();
            try
            {
                Temp = (from v in context.Videogames
                        where v.VideogameName.Contains(search)
                        select v).ToList<Videogame>();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return Temp;
        }

        public static bool DeleteGameFromId(int id) { 
        
            using GameContext context = new GameContext();
            try
            {
                var remove = (from v in context.Videogames
                              where v.VideogameId == id                                
                              select v).FirstOrDefault();

                if (remove != null)
                {
                    context.Remove(remove);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;


        }

        public static bool AddSoftHouse(SoftwareHouse house)
        {
            bool ans = false;


            using GameContext context = new GameContext();
            try
            {
                context.Add(house);
                context.SaveChanges();
                ans = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return ans;

        }


    }
}
