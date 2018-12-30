using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PROP;
using System.Data;
using System;

namespace DAL
{
    public class DALTournoi
    {
        public int CreateTournoi(string TournoiName)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("_TournoiName", TournoiName));

            return sqlHelper.executeSP<int>(parameters, "InsertTournoi");
        }

        public List<PROPTournoi> getAllTournoi()
        {
            List<PROPTournoi> TournoiList = new List<PROPTournoi>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "SelectTournoi");


            PROP.PROPTournoi Tournoi;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                int? EquipB = drow[4] is DBNull? default(Nullable<int>) : Convert.ToInt32(drow[4]);


                Tournoi = new PROP.PROPTournoi(
                    Convert.ToInt32(drow[0].ToString()),
                    Convert.ToInt32(drow[1].ToString()),
                    Convert.ToDateTime(drow[2]),
                  
                    Convert.ToInt32(drow[3].ToString()),
                      EquipB,
                    drow[5].ToString(),
                    drow[6].ToString(),
                    Convert.ToInt32(drow[7].ToString()),
                    Convert.ToInt32(drow[8].ToString())

                    );
                TournoiList.Add(Tournoi);
            }

            return TournoiList;
        }

        public List<PROPTournoi> getTournoi(string searchTournoi)
        {
            List<PROPTournoi> TournoiList = new List<PROPTournoi>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>(); 
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "SelectTournoi");

            PROPTournoi Tournoi;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                Tournoi = new PROP.PROPTournoi(
                    Convert.ToInt32(drow[0].ToString()),
                    Convert.ToInt32(drow[1].ToString()),
                    Convert.ToDateTime(drow[2].ToString()),
                    Convert.ToInt32(drow[3].ToString()),
                    Convert.ToInt32(drow[4].ToString()),
                    drow[5].ToString(),
                    drow[6].ToString(),
                    Convert.ToInt32(drow[7].ToString()),
                    Convert.ToInt32(drow[8].ToString())
                    );
                TournoiList.Add(Tournoi);
            }

            return TournoiList;
        }

        public int DeleteTournoi(int TournoiID)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_TournoiID", TournoiID));
            return sqlHelper.executeSP<int>(lstParameter, "DeleteTournoi");
        }

        public PROPTournoi GetTournoiById(int TournoiID)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_TournoiID", TournoiID));
            var resultSet = sqlHelper.executeSP<DataSet>(lstParameter, "SelectTournoiByID");

            foreach (DataRow drow in resultSet.Tables[0].Rows)
                return new PROP.PROPTournoi(
                      Convert.ToInt32(drow[0].ToString()),
                      Convert.ToInt32(drow[1].ToString()),
                      Convert.ToDateTime(drow[2].ToString()),
                      Convert.ToInt32(drow[3].ToString()),
                      Convert.ToInt32(drow[4].ToString()),
                      drow[5].ToString(),
                      drow[6].ToString(),
                    Convert.ToInt32(drow[7].ToString()),
                    Convert.ToInt32(drow[8].ToString())
                      );


            return null;
        }

        public void UpdateTournoi(PROPTournoi Tournoi)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_TournoiID", Tournoi.Id));
            lstParameter.Add(new MySqlParameter("_TournoiName", Tournoi.EquipeANom));
            sqlHelper.executenonquery(lstParameter, "UpdateTournoiName");
        }
    }
}
