using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
    public partial class HMSContext : IStoredProcedures
    {
       public IEnumerable<Content> GetContent(string FREETEXT)
       {
           var content = new SqlParameter("@FREETEXT", SqlDbType.NVarChar, 2000);
           content.Value = FREETEXT;
          
           return Database.SqlQuery<Content>("FINDCONTENT  @FREETEXT", content);
          
       }

       public string NextQuizRandom(int quizId ,int questionId)
       {
           string connectionString = ConfigurationManager.ConnectionStrings["HMSContext"].ConnectionString;
           SqlConnectionStringBuilder SConn = new SqlConnectionStringBuilder(connectionString);
           SqlConnection con = new SqlConnection();
           con.ConnectionString = connectionString;
           con.Open();
           SqlCommand cmd = new SqlCommand();
           cmd.CommandText = "NextQuiz";
           cmd.CommandType = CommandType.StoredProcedure;
           SqlParameter par = new SqlParameter("@QuizId", SqlDbType.Int);
           cmd.Parameters.Add(par).Value = quizId;
           SqlParameter par1 = new SqlParameter("@QuestionId", SqlDbType.Int);
           cmd.Parameters.Add(par1).Value = questionId;
           SqlParameter par2 = new SqlParameter("@Msg", SqlDbType.VarChar, 2000);
           par2.Direction = ParameterDirection.Output;
           cmd.Parameters.Add(par2);
           cmd.Connection = con;
           cmd.ExecuteNonQuery();
           string Msg = "";
           Msg = par2.Value.ToString();
           con.Close();
           con.Dispose();
           cmd.Dispose();
           return Msg;
       }
    }
}
