using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PROP;
using System.Data;
using System;

namespace DAL
{
    public class DALEquipe
    {
        public int CreateEquipe(string EquipeName)
        {            
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("_EquipeName", EquipeName));

            return sqlHelper.executeSP<int>(parameters, "InsertEquipe");
        }

        public List<PROPEquipe> getAllEquipe()
        {
            List<PROPEquipe> EquipeList = new List<PROPEquipe>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "getAllEquipe");
             
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            { 
                PROPEquipe Equipe = new PROPEquipe(Convert.ToInt32(drow[0].ToString()), drow[1].ToString());
                EquipeList.Add(Equipe);
            }

            return EquipeList;
        }

        public List<PROPEquipe> getEquipe(string searchEquipe)
        {
            List<PROPEquipe> EquipeList = new List<PROPEquipe>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("_EquipeName", searchEquipe));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "SelectEquipeByName");

            PROPEquipe Equipe;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                Equipe = new PROPEquipe(Convert.ToInt32(drow[0].ToString()), drow[1].ToString());
                EquipeList.Add(Equipe);
            }

            return EquipeList;
        }

        public int DeleteEquipe(int EquipeID)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_EquipeID", EquipeID));
            return sqlHelper.executeSP<int>(lstParameter, "DeleteEquipe");
        }
        public int DeleteEquipe(PROPEquipe Equipe)
        {
            return DeleteEquipe(Equipe.Id); 
        }

        public PROPEquipe GetEquipeById(int EquipeID)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_EquipeID", EquipeID)); 
            var resultSet = sqlHelper.executeSP<DataSet>(lstParameter, "SelectEquipeByID");
             
            foreach (DataRow drow in resultSet.Tables[0].Rows)
              return  new PROPEquipe(Convert.ToInt32(drow[0].ToString()), drow[1].ToString());
        
             
            return null; 
        }

        public void UpdateEquipe(PROPEquipe Equipe)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_EquipeID", Equipe.Id));
            lstParameter.Add(new MySqlParameter("_EquipeName", Equipe.Nom));
            sqlHelper.executenonquery(lstParameter, "UpdateEquipeName");
        }
    }
}
