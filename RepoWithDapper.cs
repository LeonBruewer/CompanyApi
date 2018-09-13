using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using myCompanyDB.Model;

// Using Verweis für Dapper. Dieser Erweitert die SQLConnection
using Dapper;

namespace myCompanyDB.Repository
{
    class CompanyRepo
    {
        public List<Company> Read(SqlConnection conn)
        {
            string query = @"SELECT Id,
                                    Name,
                                    Business 
                             FROM viCompany";
            /**
             * Dapper erweitert die SQL Connection um einige ausführbare befehle
             * In den spitzen Klammern kommt das Model, welches gemappt werden soll
             */
            var companyList = conn.Query<Company>(query).ToList();
            return companyList;
        }
        public Company ReadById(SqlConnection conn, int id)
        {
            // Query
            string query = @"SELECT Id,
                                    Name,
                                    Business 
                             FROM viCompany
                            WHERE Id = @Id";

            // DynamicParameters ist einer Dapper Funktion, welches für die Einbindung der Parameter zuständig ist.
            var param = new DynamicParameters();
            param.Add("@Id", id);

            var company = conn.QueryFirstOrDefault<Company>(query, param);

            return company;
        }

        public Company AddOrUpdate(SqlConnection conn, Company data)
        {
            // Die Query für die Ausführung einer SP enthält nur den Namen der SP.
            string companySelect = "spCompany";
            
           // Parameter, die in die SP geladen werden sollen
            var param = new DynamicParameters();
            param.Add("@Name", data.Name);
            param.Add("@Business", data.Business);
            param.Add("@Id", data.Id);
            
            /**
             * - Query wurde angepasst, sodass es den veränderten Eintrag zurück gibt
             * - FirstOrDefault gibt den ersten Wert aus, wenn der vorhanden es, ansonsten null
             */ 
            var company = conn.QueryFirstOrDefault<Company>(companySelect, param, null, null,
                CommandType.StoredProcedure);
           
            return company;
        }

        public bool Delete(SqlConnection conn, int id)
        {
            // Query aufstellen
            string companySelect = "spDeleteCompany";

            // Parameter einbinden
            var param = new DynamicParameters();
            param.Add("@Id", id);

            // Ausführen
            var result = conn.Execute(companySelect, param, null, null,
                CommandType.StoredProcedure);

            return result > 0;
        }
    }
}