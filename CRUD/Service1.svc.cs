using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Services;
using BAL;
using Logging;
using PROP;

namespace WebPlayer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code, le fichier svc et le fichier de configuration.
    public class Service1 : IService1
    {
        [WebMethod]
        public string DoWork()
        {
            return "hello";
        }

        [WebMethod]
        public string CreateEquipe(string contryName)
        {

            BALEquipe equipe = new BALEquipe();

            try
            {
                int returnValue = equipe.CreateEquipe(contryName);
                if (returnValue > 0)
                {
                    return "Country is created successfully ";

                }
                else
                {
                    return "Incorrect User Inputs.";
                }
            }
            catch (Exception ex)
            {
                clsLogging logError = new clsLogging();
                logError.WriteLog(ex);
            }
            return "hello";
        }

        [WebMethod]
        public List<PROP.PROPTournoi> getTournoi()
        {
            BALTournoi balTournoi = new BALTournoi();
            return balTournoi.getAllTournoi();
        }

        [WebMethod]
        public List<PROP.PROPJoueur> getJoueur()
        {
            BALJoueur balJoueur = new BALJoueur();
            return balJoueur.getJoueur(null);
        }



        public int AddBut(int id, int equipeId, int tournoiId, int joueurId, DateTime date)
        {
            BALBut balBut = new BALBut();
            return balBut.CreateBut(0,  tournoiId,equipeId, joueurId, date);
        }
    }
}
