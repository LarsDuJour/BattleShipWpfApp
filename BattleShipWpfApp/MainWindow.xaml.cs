using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleShipWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static int gridSize = 10;
        String[,] gridArray;
        Button[,] buttonArray;
        public static int MissCount = 0;

        public MainWindow()
        {

            InitializeComponent();
            gridArray = new String[gridSize, gridSize];
            buttonArray = new Button[gridSize, gridSize];
            TextBlock numberOfMissedHits = new TextBlock();
            numberOfMissedHits.Text = "Du har missed 0 gange";
            numberOfMissedHits.Margin = new Thickness(2, 2, 2, 2);
            ViewGrid.Children.Add(numberOfMissedHits);

            for (int i = 0; i < gridSize+1; i++)
            {
                RowDefinition rd = new RowDefinition();
                rd.Height = new GridLength(50, GridUnitType.Pixel);
                ViewGrid.RowDefinitions.Add(rd);

                ColumnDefinition cd = new ColumnDefinition();
                cd.Width = new GridLength(50, GridUnitType.Pixel);
                ViewGrid.ColumnDefinitions.Add(cd);
            }

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    gridArray[i, j] = "";
                }
            }

            gridArray = PlaceringsAlgoritme.Placering(2, gridArray);
            gridArray = PlaceringsAlgoritme.Placering(3, gridArray);
            gridArray = PlaceringsAlgoritme.Placering(3, gridArray);
            gridArray = PlaceringsAlgoritme.Placering(4, gridArray);
            gridArray = PlaceringsAlgoritme.Placering(5, gridArray);

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Button btn = new Button();
                    btn.Click += gridClicked(i, j);
                    btn.Content = "knap?";
                    btn.Background = Brushes.Aquamarine;
                    buttonArray[i, j] = btn;
                    btn.Margin = new Thickness(2, 2, 2, 2);
                    ViewGrid.Children.Add(btn);
                    Grid.SetColumn(btn, i);
                    Grid.SetRow(btn, j);
                }
            }

            //reset button
            Button btnReset = new Button();
            btnReset.Content = "Reset";
            //btnReset.Click = Reset(); doesnt exist yet
            btnReset.Width = 50;
            btnReset.Height = 50;
            btnReset.Margin = new Thickness(2, 2, 2, 2);
            ViewGrid.Children.Add(btnReset);
            Grid.SetColumn(btnReset, 0);
            Grid.SetRow(btnReset, 11);

            //reveal button
            Button btnReveal = new Button();
            btnReveal.Content = "Reveal";
            btnReveal.Click += reveal();
            btnReveal.Width = 50;
            btnReveal.Height = 50;
            btnReveal.Margin = new Thickness(2, 2, 2, 2);
            ViewGrid.Children.Add(btnReveal);
            Grid.SetColumn(btnReveal, 1);
            Grid.SetRow(btnReveal, 11);






        }

        private RoutedEventHandler reveal()
        {
            return (btnReveal, e) =>
            {
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        buttonArray[i, j].Content = gridArray[i, j];
                    }
                }
            };
        }

        private RoutedEventHandler gridClicked(int i, int j)
        {

            //det her er faktisk bare en utroligt lang lambda expression på en linje
            return (btn, e) =>
            {

                if (gridArray[i, j].Equals("ship"))
                {
                    //its a hit!
                    buttonArray[i, j].Background = Brushes.Red;
                    buttonArray[i, j].Content = "HIT!";
                }
                else
                {
                    MissCount++;
                    //its a miss!
                    buttonArray[i, j].Background = Brushes.Blue;
                    buttonArray[i, j].Content = "miss";
                }
            };

        }


            }
}
