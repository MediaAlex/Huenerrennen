using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO.IsolatedStorage;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;

namespace Hühnerrennen
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        //Collections definieren
        public static ObservableCollection<Spieler> listeSpieler;
        public static ObservableCollection<Huener> listeHuehner;

        Spieler ls = new Spieler();
        Huener lh = new Huener();

        //Start der Anwendung
        public void Application_Startup(object sender, StartupEventArgs e)
        {
            //Collection Befüllen
            listeSpieler = new ObservableCollection<Spieler>();

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

            //Collection Befüllen
            listeHuehner = new ObservableCollection<Huener>();

            for (int i = 0; i < 4; i++)
            {
                listeHuehner.Add(new Huener()
                {
                    huhnName = lh.huenerNamen[i],
                    huhnPfad = lh.huenerPfad[i]
                });
            }
        } 
    }
}
