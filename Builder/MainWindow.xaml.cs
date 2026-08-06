using Builder.Test;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Builder.Services;
using Builder.Models;
using Builder.Data;


namespace Builder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Build? currentBuild;

        public MainWindow()
        {
            InitializeComponent();
            EntityList.ItemsSource = Sample.Entities;
            ModList.ItemsSource=Sample.Mods;
            
            
            
            
            
            
        }

        private void EntityList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Entity selected = (Entity)EntityList.SelectedItem;
            currentBuild = new Build
            {
                Entity = selected
            };
            EntityList.Visibility = Visibility.Collapsed;
            UpdateLayout();
            RefreshBuild();
            
        }

        private void Add_Mod_Click(object sender, RoutedEventArgs e)
        {
            if(currentBuild==null) return;

            if (ModList.SelectedItem is not Mod selectedMod) return;
            if (currentBuild.Mods.Count >= 8)
            {
                MessageBox.Show("Too much mods");
                return;
            }
            currentBuild.Mods.Add(selectedMod);
            RefreshBuild();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if(currentBuild==null) return;

            StatCalculator calculator = new();

            currentBuild.CalculatedStats = calculator.Calculate(currentBuild);
            StatList.Text = $"";
            StatList.Text = $"Stats:\n";

            foreach (var stat in currentBuild.CalculatedStats) {
                StatList.Text += $"{stat.Name}: {stat.Value}\n\n";
            }
        }

        private void RefreshBuild()
        {
            var slots=new List<object>();

            foreach (var mod in currentBuild.Mods) {
                slots.Add(mod);
            }
            while (slots.Count < 8)
                slots.Add(new EmptySlot());
            BuildOutput.ItemsSource = slots;
        }

        private void ShowEntityList_Click(object sender, RoutedEventArgs e)
        {
            if (EntityList.Visibility == Visibility.Collapsed)
            {
                EntityList.Visibility = Visibility.Visible;
            }
        }
    }
}