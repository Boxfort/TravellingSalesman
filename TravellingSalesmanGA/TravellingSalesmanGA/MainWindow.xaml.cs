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

namespace TravellingSalesmanGA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool initialising;

        public MainWindow()
        {
            initialising = true;

            InitializeComponent();

            txtMutation.Text = sliderMutation.Minimum.ToString();
            txtGenerations.Text = sliderGenerations.Minimum.ToString();
            txtPopulation.Text = sliderPopulation.Minimum.ToString();
            txtTournament.Text = sliderTournament.Minimum.ToString();

            initialising = false;
        }

        private void sliderMutation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (initialising)
                return;

            txtMutation.Text = sliderMutation.Value.ToString();
        }

        private void sliderGenerations_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (initialising)
                return;

            txtGenerations.Text = sliderGenerations.Value.ToString();
        }

        private void sliderPopulation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (initialising)
                return;

            txtPopulation.Text = sliderPopulation.Value.ToString();
            sliderTournament.Maximum = (int) sliderPopulation.Value / 2;
            txtTournament.Text = sliderTournament.Value.ToString();
        }

        private void sliderTournament_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (initialising)
                return; 

            txtTournament.Text = sliderTournament.Value.ToString();
        }

        private void checkElite_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
