using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace KlasserOgObjekter
{
    public partial class MainWindow : Window
    {

        BitmapImage HarryStandImg = new BitmapImage(new Uri("C:/Users/nico936d/Documents/S-2/Uge_34/Onsdag_KlasserOgObjeker/WPF_Gaming3/KlasserOgObjekter/HarryImg.png"));
        BitmapImage HarryAttackImg = new BitmapImage(new Uri("C:/Users/nico936d/Documents/S-2/Uge_34/Onsdag_KlasserOgObjeker/WPF_Gaming3/KlasserOgObjekter/HarryAttackImg.png"));
        BitmapImage VoldemortStandImg = new BitmapImage(new Uri("C:/Users/nico936d/Documents/S-2/Uge_34/Onsdag_KlasserOgObjeker/WPF_Gaming3/KlasserOgObjekter/VoldemortImg.png"));
        BitmapImage VoldemortAttackImg = new BitmapImage(new Uri("C:/Users/nico936d/Documents/S-2/Uge_34/Onsdag_KlasserOgObjeker/WPF_Gaming3/KlasserOgObjekter/VoldemortAttackImg.png"));

        
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void PlayerAttack(object sender, RoutedEventArgs e)
        {
            AttackBtn.IsEnabled = false;
            AnapneokBtn.IsEnabled = false;
            HarryImg.Source = HarryAttackImg;
            PcHealth.Text = MiddleClass.HarryBasicAttack();
            wait();
        }

        private void AnapneoAttack(object sender, RoutedEventArgs e)
        {
            AttackBtn.IsEnabled = false;
            AnapneokBtn.IsEnabled = false;
            HarryImg.Source = HarryAttackImg;
            PcHealth.Text = MiddleClass.HarryAnapneoAttack();
            wait();
        }

        private void checkMana()
        {
            AnapneokBtn.IsEnabled = MiddleClass.checkManaLow();
        }

        async void wait()
        {
            await Task.Delay(1000);
            HarryImg.Source = HarryStandImg;
            VoldemortImg.Source = VoldemortAttackImg;
            
            PlayerHealth.Text = $"Player Health: {MiddleClass.VoldemortAttack()}";
            await Task.Delay(1000);
            AttackBtn.IsEnabled = true;

            VoldemortImg.Source = VoldemortStandImg;
            checkMana();
        }
    }
}
