using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROP
{
    public class PROPBut
    {

        public int Id { get; set; }
        public int EquipeId { get; set; }
        public int TournoiId { get; set; }
        public int JoueurId { get; set; }
        public DateTime Date { get; set; }

        public PROPBut()
        {

        }

        public PROPBut(int id, int equipeId, int tournoiId, int joueurId, DateTime date)
        {
            this.Id = id;
            this.TournoiId = tournoiId;
            this.EquipeId = equipeId;
            this.JoueurId = joueurId;
            this.Date = date;
        }

    }
}
