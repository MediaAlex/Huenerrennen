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
using System.Windows.Shapes;

namespace Hühnerrennen
{
    /// <summary>
    /// Interaktionslogik für Archiv.xaml
    /// </summary>
    public partial class Archiv : Window
    {
        public Archiv()
        {
            InitializeComponent();
        }
    }

    //private void ToggleButton_Click(object sender, RoutedEventArgs e)
    //{

    //    ToggleButton selected = sender as ToggleButton;
    //    bool status = selected.IsChecked.Value;
    //    PruefungAktiverSpieler();

    //    if (aktiv < 2)
    //    {
    //        MessageBox.Show("Es müssen mindestens 2 Spieler am aktuellen Rennen teilnehmen.");
    //        status = false;
    //        aktiv++;
    //    }

    //    selected.IsChecked = status;

    //}

    //public void PruefungAktiverSpieler()
    //{
    //    aktiv = 0;
    //    for (int i = 0; i < App.listeSpieler.Count; i++)
    //    {
    //        if (App.listeSpieler[i].aussetzen == false)
    //        {
    //            aktiv++;
    //        }
    //    }
    //}


                //    if (stPan_spieler.Children[i].GetValue(TextBox.TextProperty) == null)
                //{
                //    if (!((bool)stPan_huehner.Children[i].GetValue(ComboBox.IsSelectedProperty)))
                //    {
                //        if (einsatz == 0 || einsatz == null)
                //        {
                //            MessageBox.Show("Bitte legen sie Ihren Spielernamen, Ihr gewähltes Huhn und Ihren Einsatz fest.");
                //            stPan_spieler.Children[i].SetValue(TextBox.BackgroundProperty, Color.FromRgb(255, 200, 190));
                //            stPan_einsatz.Children[i].SetValue(TextBox.BackgroundProperty, Color.FromRgb(255, 200, 190));
                //            stPan_huehner.Children[i].SetValue(ComboBox.BorderBrushProperty, Color.FromRgb(255, 0, 0));
                //        }
                //        MessageBox.Show("Bitte legen sie Ihren Spielernamen und Ihr gewähltes Huhn fest.");
                //        stPan_spieler.Children[i].SetValue(TextBox.BackgroundProperty, Color.FromRgb(255, 200, 190));
                //        stPan_huehner.Children[i].SetValue(ComboBox.BorderBrushProperty, Color.FromRgb(255, 0, 0));
                //    }
                //    if (einsatz == 0 || einsatz == null)
                //    {
                //        MessageBox.Show("Bitte legen sie Ihren Spielernamen und Ihren Einsatz fest.");
                //        stPan_spieler.Children[i].SetValue(TextBox.BackgroundProperty, Color.FromRgb(255, 200, 190));
                //        stPan_einsatz.Children[i].SetValue(TextBox.BackgroundProperty, Color.FromRgb(255, 200, 190));
                //    }
                //}
                //if (((bool)stPan_huehner.Children[i].GetValue(ComboBox.IsSelectedProperty)))
                //{
                //    if (einsatz == 0 || einsatz == null)
                //    {
                //        MessageBox.Show("Bitte legen sie Ihr gewähltes Huhn und Ihren Einsatz fest.");
                //        stPan_einsatz.Children[i].SetValue(TextBox.BackgroundProperty, Color.FromRgb(255, 200, 190));
                //        stPan_huehner.Children[i].SetValue(ComboBox.BorderBrushProperty, Color.FromRgb(255, 0, 0));
                //    }
                //    MessageBox.Show("Bitte legen sie Ihren Spielernamen, Ihr gewähltes Huhn und Ihren Einsatz fest.");
                //    stPan_huehner.Children[i].SetValue(ComboBox.BorderBrushProperty, Color.FromRgb(255, 0, 0));
                //}
                //if (einsatz == 0 || einsatz == null)
                //{
                //MessageBox.Show("Bitte legen sie Ihren Einsatz fest.");
                //stPan_einsatz.Children[i].SetValue(TextBox.BackgroundProperty, Color.FromRgb(255, 200, 190));
                //}

}
