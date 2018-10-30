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
                int horisontalt = rnd.Next(0, MainWindow.gridSize-shipLength-1);
                int vertikalt = rnd.Next(0, MainWindow.gridSize);

                bool kanPlaceres = FreeSpaceForShipLength(horisontalt, vertikalt, shipLength, 0, true, grid, true);

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

        private static bool FreeSpaceForShipLength(int horisontal, int vertical, int shiplength, int counter, bool canBePlaced, string[,] grid, bool horisontalYesNo)
        {
            if (horisontalYesNo)
            {
                if (!grid[horisontal + counter, vertical].Equals(""))
                {
                    canBePlaced = false;
                }
            }
            else
            {
                if (!grid[horisontal, vertical + counter].Equals(""))
                {
                    canBePlaced = false;
                }
            }
            
            if (!(counter >= shiplength))
            {
                canBePlaced = FreeSpaceForShipLength(horisontal, vertical, shiplength, ++counter, canBePlaced, grid, horisontalYesNo);
            }
            return canBePlaced;
        }

        private static string[,] PlacerVertikalt(int shipLength, string[,] grid)
        {
            while (true)
            {
                
                int horisontalt = rnd.Next(0, MainWindow.gridSize);
                int vertikalt = rnd.Next(0, MainWindow.gridSize-shipLength-1);

                bool kanPlaceres = FreeSpaceForShipLength(horisontalt, vertikalt, shipLength, 0, true, grid, false);

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
