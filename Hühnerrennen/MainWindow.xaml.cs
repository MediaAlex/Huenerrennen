using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Threading;
using System.Globalization;
using System.Windows.Controls.Primitives;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media.Animation;
using System.Media;
using System.Reflection;

namespace Hühnerrennen
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     
        public MainWindow()
        { 
            InitializeComponent();

        }

        //Globale Variablen
        AnimationClock uhr = null;
        double ziel;
        Random random = new Random();
        DispatcherTimer timer = new DispatcherTimer();
        List<Image> rennHuehner;
        String siegerBild;  
        bool gesetzt;
        MediaPlayer mediaPlayer;
        
        //Seite wird geladen
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WettBueroSetzen();
            SetKIeinsatz();
            ziel = (double)zielLinie.GetValue(Canvas.LeftProperty);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 15);
            timer.Tick +=new EventHandler(timer_Tick);
            RennfeldBesetzen();
        }

        private void RennfeldBesetzen()
        {
            tBl_huhn1.SetValue(TextBlock.TextProperty, App.listeHuehner[0].huhnName);
            tBl_huhn2.SetValue(TextBlock.TextProperty, App.listeHuehner[1].huhnName);
            tBl_huhn3.SetValue(TextBlock.TextProperty, App.listeHuehner[2].huhnName);
            tBl_huhn4.SetValue(TextBlock.TextProperty, App.listeHuehner[3].huhnName);

            //BitmapImage[] bit_img = new BitmapImage[App.listeHuehner.Count];
            //for (int i = 0; i < App.listeHuehner.Count; i++)
            //{
            //    bit_img[i].BeginInit();
            //    bit_img[i].UriSource = new Uri(App.listeHuehner[i].huhnPfad, UriKind.RelativeOrAbsolute);
            //    bit_img[i].EndInit();
            //}

            //img_huhn1.Source = bit_img[0];
            //img_huhn2.Source = bit_img[1];
            //img_huhn3.Source = bit_img[2];
            //img_huhn4.Source = bit_img[3];
        }

        //Werte in Felder im Wettbüro belegen
        public void WettBueroSetzen()
        {
            //MessageBox.Show(App.listeSpieler[2].spieler + App.listeSpieler[2].kI_checked);
            for (int i = 0; i < App.listeHuehner.Count; i++)
            {
                stPan_huehner.Children[i].SetValue(ComboBox.ItemsSourceProperty, App.listeHuehner);
            }
            for (int i = 0; i < 4; i++)
            {
                if (App.listeSpieler[i].kI_checked == true)
                {
                    stPan_spieler.Children[i].SetValue(TextBox.TextProperty, App.listeSpieler[i].spieler);
                    stPan_budget.Children[i].SetValue(TextBlock.TextProperty, App.listeSpieler[i].budget.ToString());
                    stPan_chB.Children[i].SetValue(CheckBox.IsCheckedProperty, App.listeSpieler[i].kI_checked);
                    stPan_spieler.Children[i].SetValue(TextBox.IsEnabledProperty, false);
                    stPan_huehner.Children[i].IsEnabled = false;
                    stPan_einsatz.Children[i].IsEnabled = false;
                }
                else
                {
                    stPan_budget.Children[i].SetValue(TextBlock.TextProperty, App.listeSpieler[i].budget.ToString());
                    stPan_einsatz.Children[i].SetValue(TextBox.TextProperty, App.listeSpieler[i].einsatz.ToString());
                }
            }
        }

        //BarIcon Start: Rennen wird gestartet
        private void but_start_Click(object sender, RoutedEventArgs e)
        {
            this.gesetzt = true;
            setProperties(gesetzt);

            if (gesetzt == true)
            {
                mediaPlayer = new MediaPlayer();
                mediaPlayer.Open(new Uri("Sounds/Chickens 03.wav", UriKind.RelativeOrAbsolute));
                mediaPlayer.Play();
                mediaPlayer.MediaEnded += new EventHandler(mediaPlayer_MediaEnded);

                WettBueroSetzen();
                timer.Start();
                but_reset.IsEnabled = false;
                but_start.IsEnabled = false;
            }
            else
            {
                timer.Stop();
                MessageBox.Show("Bitte belegen Sie die markierten Felder sinnig.");
            }
        }

        void mediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            mediaPlayer.Play();
        }

        //Werte von Wettbüro in ObservableCollection schreiben
        private void setProperties(bool gesetzt)
        {
            double einsatz;

            for (int i = 0; i < App.listeSpieler.Count; i++)
            {
                stPan_spieler.Children[i].SetValue(TextBox.BackgroundProperty, Brushes.White);
                stPan_einsatz.Children[i].SetValue(TextBox.BackgroundProperty, Brushes.White);
                stPan_huehner.Children[i].SetValue(ComboBox.BorderBrushProperty, Brushes.DarkSlateGray);

                Double.TryParse((stPan_einsatz.Children[i] as TextBox).Text, out einsatz);
                App.listeSpieler[i].spieler = stPan_spieler.Children[i].GetValue(TextBox.TextProperty).ToString();
                App.listeSpieler[i].einsatz = einsatz;
                App.listeSpieler[i].gewaehltesHuhn = (int)stPan_huehner.Children[i].GetValue(ComboBox.SelectedIndexProperty);

                if (stPan_spieler.Children[i].GetValue(TextBox.TextProperty).ToString() == "")
                {
                    stPan_spieler.Children[i].SetValue(TextBox.BackgroundProperty, Brushes.PeachPuff);
                    this.gesetzt = false;
                }
                if (((int)stPan_huehner.Children[i].GetValue(ComboBox.SelectedIndexProperty)) < 0)
                {
                    stPan_huehner.Children[i].SetValue(ComboBox.BorderBrushProperty, Brushes.Red);
                    this.gesetzt = false;
                }
                if ((int)einsatz == 0)
                {
                    stPan_einsatz.Children[i].SetValue(TextBox.BackgroundProperty, Brushes.PeachPuff);
                    this.gesetzt = false;
                }
            }
            if (gesetzt == true)
            {
                for (int i = 0; i < App.listeSpieler.Count; i++)
                {
                    App.listeSpieler[i].budget -= App.listeSpieler[i].einsatz;
                }   
            }
        }

        //Rennablauf 
        void timer_Tick(object sender, EventArgs e)
        {
            rennHuehner = new List<Image> { img_huhn1, img_huhn2, img_huhn3, img_huhn4 };
            img_huhn1.SetValue(Canvas.LeftProperty, (double)rennHuehner[0].GetValue(Canvas.LeftProperty) + random.Next(1, 4));
            img_huhn2.SetValue(Canvas.LeftProperty, (double)rennHuehner[1].GetValue(Canvas.LeftProperty) + random.Next(1, 4));
            img_huhn3.SetValue(Canvas.LeftProperty, (double)rennHuehner[2].GetValue(Canvas.LeftProperty) + random.Next(1, 4));
            img_huhn4.SetValue(Canvas.LeftProperty, (double)rennHuehner[3].GetValue(Canvas.LeftProperty) + random.Next(1, 4));

            for (int i = 0; i < rennHuehner.Count; i++)
            {
                if ((double)rennHuehner[i].GetValue(Canvas.LeftProperty) + 51 > ziel)
                {
                    timer.Stop();

                    for (int j = 0; j < App.listeSpieler.Count; j++)
                    {
                        if (App.listeSpieler[j].gewaehltesHuhn == i)
                        {
                            App.listeSpieler[j].budget += App.listeSpieler[j].einsatz * 2;
                            stPan_budget.Children[j].SetValue(TextBlock.TextProperty, App.listeSpieler[j].budget.ToString());
                        }
                    }
                    mediaPlayer.Stop();
                    mediaPlayer.Close();
                    Siegerehrung(i);
                    but_reset.IsEnabled = true;
                }
            }
        }

        private void Siegerehrung(int i)
        {
            //tBl_siegerhuhn.SetValue(TextBlock.TextProperty, "Sieger ist: " + App.listeHuehner[i].huhnName);
            tBl_siegerhuhn.Text = "Sieger ist: " + App.listeHuehner[i].huhnName;
            siegerBild = App.listeHuehner[i].huhnPfad;

            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("Sounds/Chicken.wav", UriKind.RelativeOrAbsolute));
            mediaPlayer.Play();
            mediaPlayer.MediaEnded +=new EventHandler(mediaPlayer_MediaEnded);

            SiegAnimation(siegerBild);
        }

        private void SiegAnimation(String bild)
        {

            BitmapImage bit_img = new BitmapImage();
            bit_img.BeginInit();
            bit_img.UriSource = new Uri(siegerBild, UriKind.RelativeOrAbsolute);
            bit_img.EndInit();
            img_sieger.Source = bit_img; //Siegerhuhn wird präsentiert

            DoubleAnimation da = new DoubleAnimation();
            da.To = -30;
            da.RepeatBehavior = RepeatBehavior.Forever;
            da.AutoReverse = true;
            da.AccelerationRatio = 1;
            da.Duration = new Duration(TimeSpan.Parse("0:0:0.4"));
            uhr = da.CreateClock();
            img_sieger.ApplyAnimationClock(Canvas.TopProperty, uhr);

            uhr.Controller.Begin();
        }

        //Hühner werden auf Startposition zurückgesetzt
        private void but_reset_Click(object sender, RoutedEventArgs e)
        {
            uhr.Controller.Stop();
            but_reset.IsEnabled = false;
            img_huhn1.SetValue(Canvas.LeftProperty, (double)startLinie.GetValue(Canvas.LeftProperty) - 53);
            img_huhn2.SetValue(Canvas.LeftProperty, (double)startLinie.GetValue(Canvas.LeftProperty) - 53);
            img_huhn3.SetValue(Canvas.LeftProperty, (double)startLinie.GetValue(Canvas.LeftProperty) - 53);
            img_huhn4.SetValue(Canvas.LeftProperty, (double)startLinie.GetValue(Canvas.LeftProperty) - 53);
            but_start.IsEnabled = true;
            SetKIeinsatz();
            KIspielerWechsel();
            mediaPlayer.Stop();
            mediaPlayer.Close();
            siegerBild = null;
            img_sieger.Source = null;
            tBl_siegerhuhn.Text = null;
        }

        private void KIspielerWechsel()
        {
            for (int i = 0; i < App.listeSpieler.Count; i++)
            {
                if (App.listeSpieler[i].kI_checked == true)
                {
                    if (App.listeSpieler[i].budget < 0)
                    {
                        Spieler ersSp = new Spieler();
                        int indexErsatz = random.Next(0, 4);
                        App.listeSpieler[i].spieler = ersSp.ersatzKIspieler[indexErsatz];
                        App.listeSpieler[i].budget = 1000;
                        stPan_spieler.Children[i].SetValue(TextBox.TextProperty, App.listeSpieler[i].spieler);
                        stPan_budget.Children[i].SetValue(TextBlock.TextProperty, App.listeSpieler[i].budget.ToString());
                    }
                }
            }
        }

        private void SetKIeinsatz()
        {
            for (int i = 0; i < App.listeSpieler.Count; i++)
            {
                if (App.listeSpieler[i].kI_checked == true)
                {
                    int gewhuhn = random.Next(0, 4);
                    stPan_einsatz.Children[i].SetValue(TextBox.TextProperty, random.Next(40, 200).ToString());
                    stPan_huehner.Children[i].SetValue(ComboBox.SelectedIndexProperty, gewhuhn);
                }
            }
        }

        //Alles zurücksetzen
        private void but_allReset_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Alles wird zurückgesetzt. Auch die Spielstände.\r\nWollen sie wirklich fortfahren?",
            "Alles Zurücksetzen", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                App.listeSpieler.Clear();

                Spieler ls = new Spieler();

                for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                    {
                        App.listeSpieler.Add(new Spieler()
                        {
                            spieler = ls.spielerNamen[i],
                            budget = 1000,
                            einsatz = 0,
                            kI_checked = false
                        });
                    }
                    else
                    {
                        App.listeSpieler.Add(new Spieler()
                        {
                            spieler = ls.spielerNamen[i],
                            budget = 1000,
                            einsatz = 0,
                            kI_checked = true
                        });
                    }
                }
            }
        }

        private void checkBox_Click(object sender, RoutedEventArgs e)
        {
            int check;
            Int32.TryParse((sender as CheckBox).Name.Substring(8), out check);

            if (((bool)stPan_chB.Children[check].GetValue(CheckBox.IsCheckedProperty)))
            {
                Spieler ersSp = new Spieler();
                int gewhuhn = random.Next(0, 4);
                stPan_spieler.Children[check].SetValue(TextBox.TextProperty, ersSp.ersatzKIspieler[gewhuhn]);
                stPan_budget.Children[check].SetValue(TextBlock.TextProperty, 1000.ToString());
                stPan_huehner.Children[check].SetValue(ComboBox.SelectedIndexProperty, gewhuhn);
                stPan_einsatz.Children[check].SetValue(TextBox.TextProperty, random.Next(40, 200).ToString());
                stPan_spieler.Children[check].IsEnabled = false;
                stPan_huehner.Children[check].IsEnabled = false;
                stPan_einsatz.Children[check].IsEnabled = false;
                App.listeSpieler[check].kI_checked = true;
                App.listeSpieler[check].budget = 1000;
            }
            else
            {
                App.listeSpieler[check].budget = 1000;
                stPan_spieler.Children[check].SetValue(TextBox.TextProperty, "");
                stPan_budget.Children[check].SetValue(TextBlock.TextProperty, App.listeSpieler[check].budget.ToString());
                stPan_einsatz.Children[check].SetValue(TextBox.TextProperty, 0.ToString());
                stPan_huehner.Children[check].SetValue(ComboBox.SelectedIndexProperty, -1);
                stPan_spieler.Children[check].IsEnabled = true;
                stPan_huehner.Children[check].IsEnabled = true;
                stPan_einsatz.Children[check].IsEnabled = true;
                App.listeSpieler[check].kI_checked = false;
                App.listeSpieler[check].budget = 1000;
            }
        }
    }
}
