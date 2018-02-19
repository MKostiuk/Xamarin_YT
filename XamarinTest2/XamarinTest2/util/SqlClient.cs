using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace XamarinTest2.util
{
    public class SqlClient
    {
        private string NumEtiquette;

        public SqlClient(string n)
        {
            NumEtiquette = n;
        }

        public string requestElem()
        {
            String num = null;

            String machineName = Environment.MachineName;
            num = machineName.Substring(4, 3);
            //num = "001";

            SqlConnection cn = new SqlConnection("Server=CLEOR" + num + "1\\SQLEXPRESS;User ID=SynchClient" + num +
                ";Database=BDDMAG;Password=CleOr;Persist Security Info=True;");

            num = null;

            String query = "SELECT [ITEMID] 'CodeArticle', [splsizename] 'Taille' FROM [BDDMAG].[ax].[INVENTSERIAL] where INVENTSERIALID = '" + this.NumEtiquette + "'";


            String codeArticle = null;
            String taille = null;
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);

                SqlDataReader aReader = cmd.ExecuteReader();
                // si il y au moins une ligne
                if (aReader.HasRows)
                {
                    aReader.Read();

                    codeArticle = aReader.GetValue(0).ToString();

                    taille = aReader.GetValue(1).ToString();

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
            }

            //On concatène code article et taille pour obtenir le numéro étiquette
            num = codeArticle + taille;

            return num;
        }
    }
}
