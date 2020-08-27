using KlasserOgObjekter.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
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
        // Her laver jeg 4 bitmapimages som holder på hver sin sti til et billede.
        BitmapImage HarryStandImg = new BitmapImage(new Uri(@$"{MiddleClass.Dir}\HarryImg.png"));
        BitmapImage HarryAttackImg = new BitmapImage(new Uri(@$"{MiddleClass.Dir}\HarryAttackImg.png"));
        BitmapImage VoldemortStandImg = new BitmapImage(new Uri(@$"{MiddleClass.Dir}\VoldemortImg.png"));
        BitmapImage VoldemortAttackImg = new BitmapImage(new Uri(@$"{MiddleClass.Dir}\VoldemortAttackImg.png"));



        public MainWindow()
        {
            InitializeComponent();
            // Her laver jeg HarryImg billede sti om til en af de urler som jeg lavede oppe i toppen
            HarryImg.Source = HarryStandImg;
            // Det samme her
            VoldemortImg.Source = VoldemortStandImg;
            // Her sætter jeg bagrundsbilledet til at være et billede
            startBg.Source = new BitmapImage(new Uri($@"{MiddleClass.Dir}\StartBg.jpg"));

            shopBg.Source = new BitmapImage(new Uri($@"{MiddleClass.Dir}\shopBg.jpg"));
        }

        // Menuer
        private void shopBtn_Clicked(object sender, RoutedEventArgs e)
        {
            StartC.Visibility = Visibility.Hidden;
            Game.Visibility = Visibility.Hidden;
            Shop.Visibility = Visibility.Visible;
            for(int i = 0; i < WandReposetory.WandList().Count; i++)
            {
                Image wandImg = new Image();
                wandImg.Source = new BitmapImage(new Uri($@"{MiddleClass.Dir}\wands\wand{i}.jpg"));
                wandImg.Width = 100;
                Button wandBtn = new Button();
                wandBtn.Content = wandImg;
                Canvas.SetLeft(wandBtn, i * 120);

                wandBtn.Name = $"{WandReposetory.WandList()[i].Name}";
                wandBtn.Click += new RoutedEventHandler(shopElement);
                wandBtn.Tag = wandImg.Source.ToString();
                Shop.Children.Add(wandBtn);
            }
            goldCounter.Text = MiddleClass.returnGold();
        }

        public void shopElement(object sender, RoutedEventArgs e)
        {
            Button srcButton = e.Source as Button;

            foreach (Wand wands in WandReposetory.WandList())
            {
                if (srcButton.Name == wands.Name)
                {
                    
                    MiddleClass.giveHarryStrenght(wands.WandDamage);
                    
                }
            }
        }

        public void goldUpdater(int goldCount)
        {
            goldCounter.Text = goldCount.ToString();
        }

        private void backToGame(object sender, RoutedEventArgs e)
        {
            StartC.Visibility = Visibility.Hidden;
            Game.Visibility = Visibility.Visible;
            Shop.Visibility = Visibility.Hidden;
        }

        // Shop
        // Skal lære at loope igennem en list
        // Skal lære hvordan jeg tilgår en Class som er inde i en mappe fx: DAL/WandReposetory

        // Her angriber player voldemort med et basic angrab
        private void PlayerAttack(object sender, RoutedEventArgs e)
        {
            AttackBtn.IsEnabled = false;
            AnapneokBtn.IsEnabled = false;
            HarryImg.Source = HarryAttackImg;
            PcHealth.Text = MiddleClass.HarryBasicAttack();
            wait();
        }

        // Her angriber player voldemort med AnapneoAttack
        private void AnapneoAttack(object sender, RoutedEventArgs e)
        {
            AttackBtn.IsEnabled = false;
            AnapneokBtn.IsEnabled = false;
            HarryImg.Source = HarryAttackImg;
            PcHealth.Text = MiddleClass.HarryAnapneoAttack();
            wait();
        }

        // Her tjekker jeg for mana
        private void checkMana()
        {
            AnapneokBtn.IsEnabled = MiddleClass.checkManaLow();
        }

        // Sætter pc og player level text til at være hvad deres level er
        public void levelCheck()
        {
            PcLevel.Text = MiddleClass.vLvlCheck();
            PlayerLevel.Text = MiddleClass.hLvlCheck();
        }

        // Det her er en wait
        async void wait()
        {
            await Task.Delay(1000);
            HarryImg.Source = HarryStandImg;
            VoldemortImg.Source = VoldemortAttackImg;
            
            PlayerHealth.Text = $"Player Health: {MiddleClass.VoldemortAttack()}";
            await Task.Delay(1000);
            AttackBtn.IsEnabled = true;
            VoldemortImg.Source = VoldemortStandImg;
            levelCheck();
            checkMana();
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            Game.Visibility = Visibility.Visible;
            StartC.Visibility = Visibility.Hidden;
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
