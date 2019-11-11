using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace PFY.TableAccess
{
    class Portfolio_DU : Portfolio_AB
    {
        //プレースホルダ
        string C_insertstr = @"INSERT INTO dbo.portfolio
(
brandname   ,
brandcode   ,
market      ,
banktype    ,
markettype  ,
nisaflg     ,
shareholding,
buyprice_ave,
estprice_uni,
estprice_all,
valuation   
) VALUES
(
@brandname   ,
@brandcode   ,
@market      ,
@banktype    ,
@markettype  ,
@nisaflg     ,
@shareholding,
@buyprice_ave,
@estprice_uni,
@estprice_all,
@valuation
)";

        public override void RegistPortfolio(Portfolio pf) {

            //パラメーター取得
            //入力
            //出力

            // 接続文字列の取得
            String connectionString = ConfigurationManager.ConnectionStrings[C_DBNAME].ConnectionString;

            // データベース接続の準備
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            try
            {
                // データベースの接続オープン
                connection.Open();

                // 実行するSQLの準備
                command.Connection = connection;
                command.CommandText = C_insertstr;

                //プレースホルダにパラメーター設定
                command.Parameters.Add(new SqlParameter("@brandname", pf.brandname));
                command.Parameters.Add(new SqlParameter("@brandcode", pf.brandcode));
                command.Parameters.Add(new SqlParameter("@market", pf.market));
                command.Parameters.Add(new SqlParameter("@banktype", pf.banktype));
                command.Parameters.Add(new SqlParameter("@markettype", pf.markettype));
                command.Parameters.Add(new SqlParameter("@nisaflg", pf.nisaflg));
                command.Parameters.Add(new SqlParameter("@shareholding", pf.shareholding));
                command.Parameters.Add(new SqlParameter("@buyprice_ave", pf.buyprice_ave));
                command.Parameters.Add(new SqlParameter("@estprice_uni", pf.estprice_uni));
                command.Parameters.Add(new SqlParameter("@estprice_all", pf.estprice_all));
                command.Parameters.Add(new SqlParameter("@valuation", pf.valuation));

                // SQLの実行(INSERT,UPDATEの時)
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
            finally
            {
                // データベースの接続終了
                connection.Close();
            }
        }
    }
}
