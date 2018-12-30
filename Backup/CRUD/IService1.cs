using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebPlayer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string DoWork();  
        [OperationContract]
        string CreateEquipe(string contry);

        [OperationContract]
        List<PROP.PROPTournoi>getTournoi();
        [OperationContract]
        List<PROP.PROPJoueur> getJoueur();
        [OperationContract]
        int AddBut(int id, int equipeId, int tournoiId, int joueurId, DateTime date); 

    }
}
