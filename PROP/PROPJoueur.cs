using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROP
{
    public class PROPJoueur
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public bool Sexe { get; set; } 

        public int EquipeId { get; set; }

        public PROPJoueur()
        {

        }

        public PROPJoueur(int id, string nom, string prenom, bool sexe, int equipeId)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Sexe = sexe;
            EquipeId = equipeId;
        }
    }
}
