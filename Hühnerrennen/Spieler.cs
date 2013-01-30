using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Hühnerrennen
{
    public class Spieler
    {
        public string[] spielerNamen = { "Julia", "Frank", "Helene", "Bernd" };
        public string[] ersatzKIspieler = { "Thorsten", "Michelle", "Albert", "Anna" };
        public string spieler { set; get; }
        public double budget { set; get; }
        public double einsatz { set; get; }
        public int gewaehltesHuhn { get; set; } //Wenn in Combobox huhn gewählt wird hier speichern
        public bool kI_checked { get; set; }
    }
}
