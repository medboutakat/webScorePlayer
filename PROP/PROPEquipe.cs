using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROP
{
    public class PROPEquipe
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public PROPJoueur Joueur1 { get; set; }
        public PROPJoueur Joueur2 { get; set; } 

        public PROPEquipe()
        {
            Joueur1 = new PROPJoueur();
            Joueur2 = new PROPJoueur(); 
        }

        public PROPEquipe(int countryID, string countryName):this()
        {
            this.Id = countryID;
            this.Nom = countryName;
        }        
    }
}
