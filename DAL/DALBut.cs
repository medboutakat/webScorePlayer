using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PROP;
using System.Data;
using System;

namespace DAL
{
    public class DALBut
    {
        public int CreateBut(PROPBut But)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("_TournoiId", But.TournoiId));
            parameters.Add(new MySqlParameter("_EquipeId", But.EquipeId));
            parameters.Add(new MySqlParameter("_JoueurId", But.JoueurId));
            parameters.Add(new MySqlParameter("_Date", But.Date));  
            return sqlHelper.executeSP<int>(parameters, "InsertBut");
        }

        public List<PROPBut> getAllBut()
        {
            List<PROPBut> ButList = new List<PROPBut>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "getAllBut");


            PROPBut But;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                But = new PROPBut();

                   But.Id= Convert.ToInt32(drow[0].ToString());  
                   if (drow[1] != null && typeof(DBNull) != drow[1].GetType())
                       But.TournoiId = Convert.ToInt32(drow[1]);
                   if (drow[2] != null && typeof(DBNull) != drow[2].GetType())
                       But.EquipeId = Convert.ToInt32(drow[2]);
                   if (drow[3] != null && typeof(DBNull) != drow[3].GetType())
                       But.JoueurId = Convert.ToInt32(drow[3]);
                   ButList.Add(But);
            }

            return ButList;
        }

        public List<PROPBut> getBut(string searchBut)
        {
            List<PROPBut> ButList = new List<PROPBut>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("_ButSearch", searchBut));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "SelectBut");

            PROPBut But;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                But = new PROPBut(

                      Convert.ToInt32(drow[0].ToString()),
                    Convert.ToInt32(drow[1].ToString()),
                    Convert.ToInt32(drow[2].ToString()),
                 Convert.ToInt32(drow[3]),
                 Convert.ToDateTime(drow[3])
     );
                ButList.Add(But);
            }

            return ButList;
        }

        public int DeleteBut(PROPBut But)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_ButID", But.Id));
            return sqlHelper.executeSP<int>(lstParameter, "DeleteBut");
        }
        
        public int DeleteBut(int ButID)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_ButID", ButID));
            return sqlHelper.executeSP<int>(lstParameter, "DeleteBut");
        }

        public string GetButById(int ButID)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_Id", ButID));
            return sqlHelper.executeScaler(lstParameter, "SelectButByID");
        }

        public void UpdateBut(PROPBut But)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            //lstParameter.Add(new MySqlParameter("_Id", But.Id));
            //lstParameter.Add(new MySqlParameter("_Nom", But.Nom));
            //lstParameter.Add(new MySqlParameter("_Prenom", But.Prenom));
            //lstParameter.Add(new MySqlParameter("_Sexe", But.Sexe ? 1 : 0));
            //lstParameter.Add(new MySqlParameter("_EquipeId", But.EquipeId));
            sqlHelper.executenonquery(lstParameter, "UpdateBut");
        }
    }
}
