using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Hühnerrennen
{
    public class Huener
    {
        public string huhnName { get; set; }
        public String huhnPfad { get; set; }
        public String[] huenerPfad = {
                                    "/Images/chicken_01.png", 
                                    "/Images/chicken_02.png", 
                                    "/Images/chicken_03.png",
                                    "/Images/chicken_04.png",
                                  };
        //public Uri huhnPfad { get; set; }
        //public Uri[] huenerPfad = {
        //                            new Uri ("/Images/chicken_01.png", UriKind.Relative), 
        //                            new Uri ("/Images/chicken_02.png", UriKind.Relative), 
        //                            new Uri ("/Images/chicken_03.png", UriKind.Relative), 
        //                            new Uri ("/Images/chicken_04.png", UriKind.Relative) 
        //                          };
        public string[] huenerNamen = { "Klara", "Berta", "Ingrid", "Susi" };

    }
}
