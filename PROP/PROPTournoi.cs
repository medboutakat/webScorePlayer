using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROP
{
    public class PROPTournoi
    {
         
        public int Id { get; set; }
        public int Grade { get; set; } 
        public DateTime Date { get; set; }
        public int EquipeA { get; set; }
        public int? EquipeB { get; set; }
        public string EquipeANom { get; set; }
        public string EquipeBNom { get; set; }
    
        public int ButA { get; set; }
        public int ButB { get; set; }

        public PROPTournoi()
        {

        }

        public PROPTournoi(int id,int grade,DateTime date,int equipeA,int? equipeB,string equipeANom,string equipeBNom,int butA,int butB )
        {
            this.Id = id;
            this.Grade = grade;
            this.Date = date;
            this.EquipeA = equipeA;
            this.EquipeB = equipeB;
            this.EquipeANom = equipeANom;
            this.EquipeBNom = equipeBNom;
            this.ButA = butA;
            this.ButB = butB;
        
        }
         
    }
}
