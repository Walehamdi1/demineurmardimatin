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
using bib;

namespace WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Level level = Level.Beginner;
        Game myGame;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            myGame = new Game(level);
            myCanvas.Children.Clear();

            int y=0;
            for (int i = 0; i < myGame.Grid.GetLength(0); i++)
            {
               int w = 50 ;//(int)(this.Width/myGame.Grid.GetLength(1));

               int h = 50 ;//(int)(this.Width/myGame.Grid.GetLength(0));
                for (int j = 0; j < myGame.Grid.GetLength(1); j++)
                {
                    Button bt = new Button();
                    
                    bt.Click += Bt_Click;
                    bt.Height = h;
                    bt.Width = w;
                    bt.FontSize = 20;
                    bt.FontWeight = FontWeights.Bold;
                    Canvas.SetTop(bt,i*h);
                    
                    Canvas.SetLeft(bt,j*w);
                    //bt.Content = myGame.Grid[i,j];
                    bt.Tag = myGame.Grid[i, j];
                    myCanvas.Children.Add(bt);
                    
                }
               

            }
            

            
            

        }

        private void Bt_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button) sender; //sender as Button;
            var index = myCanvas.Children.IndexOf(b);
            
            //MessageBox.Show(b.Tag.ToString());
            int c = (int) b.Tag;
            int i = 0;
            if (c == 9)
            {
                /*foreach (Button item in myCanvas.Children)
                {
                    item.Content = item.Tag.ToString();
                }
                MessageBox.Show("Game Over !");*/
                b.Content = b.Tag.ToString();
            }
            else if (c >0)
            {
                b.Content = b.Tag.ToString();              

            }
            else
            {
               

                //var x = index / myGame.Grid.GetLength(0);
                //var y = index % myGame.Grid.GetLength(0);
                //MessageBox.Show($"{x},{y}");
                parcourirX(b);
            }


        }
        private void parcourirX(Button b, int i= 0)
        {
            
            
            int index = myCanvas.Children.IndexOf(b);
            if ( b.IsEnabled == false)
            {
                    b.Content = b.Tag;
                    if((int) b.Tag == 0 ) { 
                        parcourirY(index);
                        parcourirY(index-myGame.Grid.GetLength(0));
                        parcourirY(index+myGame.Grid.GetLength(0));

            }

            /*Button b1 ;
            b1 = (Button) myCanvas.Children[index+1];
            if (b1.Content is null)
            {
                b1.Content = b1.Tag ;
                    if ((int) b1.Tag == 0 )
                    {
                
                        if ( myCanvas.Children.IndexOf(b1) > myGame.Grid.GetLength(0)) {
                            parcourirX((Button) myCanvas.Children[myCanvas.Children.IndexOf(b1)-myGame.Grid.GetLength(0)],i+1);
                        }
                        if ( myCanvas.Children.IndexOf(b1)+myGame.Grid.GetLength(0)< myCanvas.Children.Count)
                        {
                            parcourirX((Button) myCanvas.Children[myCanvas.Children.IndexOf(b1)+myGame.Grid.GetLength(0)],i+1);
                        }

                    }
            }
            
            b1 = (Button) myCanvas.Children[index-1];
            if (b1.Content is null)
            {
                b1.Content = b1.Tag ;
                    if ((int) b1.Tag == 0 )
                    {
                
                        if ( myCanvas.Children.IndexOf(b1) > myGame.Grid.GetLength(0)) {
                            parcourirX((Button) myCanvas.Children[myCanvas.Children.IndexOf(b1)-myGame.Grid.GetLength(0)],i+1);
                        }
                        if ( myCanvas.Children.IndexOf(b1)+myGame.Grid.GetLength(0)< myCanvas.Children.Count)
                        {
                            parcourirX((Button) myCanvas.Children[myCanvas.Children.IndexOf(b1)+myGame.Grid.GetLength(0)],i+1);
                        }

                    }*/
            }
           
            /*if ((int) next_b.Tag  == 0 && next_b.Content is null )
            {
                next_b.Content = next_b.Tag;
                t(x, y - 1, step + 1);
                t(x, y + 1, step + 1);
            }
               
            next_b = (Button)myCanvas.Children[y * myGame.Grid.GetLength(0) + x+1];
            next_b.Content = next_b.Tag;
            if ((int) next_b.Tag  == 0 && next_b.Content is null )
            {
                t(x+1, y - 1);
                t(x+1, y + 1);
            }
            next_b = (Button)myCanvas.Children[y * myGame.Grid.GetLength(0) + x-1];
            next_b.Content = next_b.Tag;
            if ((int) next_b.Tag  == 0 && next_b.Content is null )
            {
                t(x-1, y - 1, step + 1);
                t(x-1, y + 1, step + 1);
            }*/
           

        }
        private void parcourirY(int index)
        {
                Button b1 = (Button) myCanvas.Children[index];
                b1.Content = b1.Tag;
                b1.IsEnabled = true;
                b1 = (Button) myCanvas.Children[index+1];
                
                /*if (index > myGame.Grid.GetLength(0))
                    {
                        t((Button) myCanvas.Children[index-myGame.Grid.GetLength(0)],i+1);

                    }
                    if ( index+myGame.Grid.GetLength(0) < myCanvas.Children.Count)
                         t((Button) myCanvas.Children[index+myGame.Grid.GetLength(0)],i+1);
                    }*/
                b1.Content = b1.Tag;
                if((int) b1.Content == 0 && !b1.HasContent )
                    {
                        
                    parcourirX(b1);
                    }
                b1 = (Button) myCanvas.Children[index-1];
                b1.Content = b1.Tag;
                if((int) b1.Content == 0 && !b1.IsEnabled)
                {
                     
                    parcourirX(b1);
                }
                
        }



        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Beginner_Checked(object sender, RoutedEventArgs e)
        {
            level = Level.Beginner;
        }

        private void Intermediate_Checked(object sender, RoutedEventArgs e)
        {
            level = Level.Intermediate;
        }

        private void Advanced_Checked(object sender, RoutedEventArgs e)
        {
            level = Level.Advanced;
        }
    }
}
