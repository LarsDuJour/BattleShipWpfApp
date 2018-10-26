using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipWpfApp
{
    class PlaceringsAlgoritme
    {
        
        private static Random rnd = new Random();


        public static string[,] Placering(int shipLength, string[,] grid)
        {
            int horisontalVertikalRnd = rnd.Next(1, 10);

            if (horisontalVertikalRnd < 6)
            {
                grid = PlacerHorisontalt(shipLength, grid);
            }
            else
            {
                grid = PlacerVertikalt(shipLength, grid);
            }

            return grid;
        }

        private static string[,] PlacerHorisontalt(int shipLength, string[,] grid)
        {
            while (true)
            {
                bool kanPlaceres = true;
                int horisontalt = rnd.Next(0, 9-shipLength);
                int vertikalt = rnd.Next(0, 9);

                for (int i = 0; i < shipLength; i++)
                {
                    if (!grid[horisontalt+i,vertikalt].Equals(""))
                    {
                        kanPlaceres = false;
                    }
                }

                if (kanPlaceres)
                {
                    for (int i = 0; i < shipLength; i++)
                    {
                        grid[horisontalt + i, vertikalt] = "ship";
                    }
                    break;
                }
            
            }

            return grid;
        }

        private static string[,] PlacerVertikalt(int shipLength, string[,] grid)
        {
            while (true)
            {
                bool kanPlaceres = true;
                int horisontalt = rnd.Next(0, 9);
                int vertikalt = rnd.Next(0, 9- shipLength);

                for (int i = 0; i < shipLength; i++)
                {
                    if (!grid[horisontalt,vertikalt+i].Equals(""))
                    {
                        kanPlaceres = false;
                    }
                }

                if (kanPlaceres)
                {
                    for (int i = 0; i < shipLength; i++)
                    {
                        grid[horisontalt, vertikalt+i] = "ship";
                    }
                    break;
                }
            
            }

            return grid;
        }

    }
}
