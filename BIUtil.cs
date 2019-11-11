using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFY
{
    class BIUtil
    {
        public void BISearchBrandCode(String brand_Code, int RCount)
        {
            //丸紅8002 35 4.5%
            //BrandYield
            //検索機能
            BrandYield_DU du = new BrandYield_DU();
            RCount = du.SearchBrandCode(brand_Code);

            //件数の判定
            if (RCount > 0)
            {
                Console.WriteLine("{0:d}件ヒット!", RCount);
            }
            else
            {
                Console.WriteLine("銘柄コードがありません");
            }

        }

        public void BIInsertBrandRec(String brand_Code, Double dividend, Double yield) 
        {
            //挿入機能
            BrandYield_DU du = new BrandYield_DU();
            du.InsertBrandRec(brand_Code, dividend, yield);
        }

        public void BIDeleteBrandRec(String brand_Code)
        {
            //削除機能
            BrandYield_DU du = new BrandYield_DU();
            du.DeleteBrandRec(brand_Code);
        }

        public void BIRegistPortfolio()
        {

            //ファイルパス
            //string filePath = @"E:\samurai.txt";
            string filePath = @"E:\test.csv";
            //                string str = sr.ReadToEnd();

            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding("Shift_JIS"));

                List<string> arr = new List<string>();
                string str = "";
                int reccnt = 1;

                //読み終わるまでループ
                while (sr.Peek() != -1)
                {
                    str = sr.ReadLine();
                    Console.WriteLine(str);

                    //ヘッダは除外
                    if (reccnt > 1)
                    {
                        arr.Add(str);
                        int now_idx = arr.Count() - 1;

                        //カンマ区切りで分割する
                        Portfolio pf = new Portfolio();
                        pf.setAll(arr[now_idx]);

                        //登録ＳＱＬを発行する
                        TableAccess.Portfolio_DU du = new TableAccess.Portfolio_DU();
                        du.RegistPortfolio(pf);

                    }

                    reccnt++;
                }

                sr.Close();

            }
            else
            {
                Console.WriteLine("ファイルが存在しません");
            }

        }

    }
}
