using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HoplonGuessingGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private atributes

        private Node root; //Binary tree root;

        public MainWindow()
        {
            this.WindowState = WindowState.Minimized;
            this.ShowInTaskbar = false;
            //InitializeComponent();
            //start game
            BuildInitialTree();
            while (true)
            {
                StartGame();
            }            
        }
        
        void BuildInitialTree()
        {
            Node sharkNode = new Node("shark");
            Node monkeyNode = new Node("monkey");
            this.root = new Node("lives in water", sharkNode, monkeyNode);
        }

        public void StartGame()
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Think of an animal...", "Guessing Game", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                //ask user first question
                this.root.Query();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
