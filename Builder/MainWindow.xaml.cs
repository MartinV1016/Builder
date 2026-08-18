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
                Entity = selected,
                CalculatedStats = selected.BaseStats.Select(stat => new Stat(stat.Name, stat.Value)).ToList()
            };
            EntityList.Visibility = Visibility.Collapsed;
            StatList.Text = $"";
            StatList.Text = $"Stats:\n";
            foreach (var item in selected.BaseStats)
            {
                StatList.Text += $"{item.Name}:{item.Value}\n\n";
            }
            UpdateLayout();
            
            RefreshBuild();
            
        }

        private void Add_Mod_Click(object sender, RoutedEventArgs e)
        {
            if(currentBuild==null) return;

            if (ModList.SelectedItem is not Mod selectedMod) return;
            if (currentBuild.Mods.Count >= 8)
            {
                MessageBox.Show("Too much mods!");
                return;
            }
            if (currentBuild.Mods.Contains(selectedMod))
            {
                MessageBox.Show("You can't have duplicate mods!");
                return;
            }
            else
            {
                currentBuild.Mods.Add(selectedMod);
            }
                
            RefreshBuild();
            CalculateButton_Click(sender, e);
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if(currentBuild==null) return;

            StatCalculator calculator = new();

            currentBuild.CalculatedStats = calculator.Calculate(currentBuild);
            StatList.Text = $"";
            StatList.Text = $"Stats:\n";

            foreach (var stat in currentBuild.CalculatedStats) {
                var baseStat=currentBuild.Entity.BaseStats.First(s => s.Name == stat.Name);
                StatList.Text += $"{stat.Name}:{baseStat.Value} -> {stat.Value}\n\n";
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

        private void Remove_Mod_Click(object sender, RoutedEventArgs e)
        {
            if (currentBuild == null) return;

            if (BuildOutput.SelectedItem is not Mod selectedMod) return;

            RemoveMod(selectedMod);
        }

        private void Remove_Selected_Mod_Click(Object sender, RoutedEventArgs e)
        {
            if(sender is Button button && button.Tag is Mod mod)
            {
                RemoveMod(mod);
            }
        }

        private void CalculateDpsButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentBuild == null) return;
            float atk = 0f;
            float spd =  0f;
            StatCalculator calculator = new StatCalculator();
            foreach(var stat in currentBuild.CalculatedStats)
            {
                if (stat.Name == "Damage")
                {
                    atk = (float)stat.Value;
                }
                else if(stat.Name == "Fire Rate")
                {
                    spd = (float)stat.Value;
                }
                else
                {
                    continue;
                }
            }
            DPSText.Text=$"Damage per Second: {calculator.CalculateDPS(atk, spd)}\n";
            
        }

        private void RemoveMod(Mod mod)
        {
            if(currentBuild == null) return;

            currentBuild.Mods.Remove(mod);
            RefreshBuild();
            CalculateButton_Click(null!, null!);
        }
    }
}