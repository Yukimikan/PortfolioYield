using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFY
{
    class Portfolio
    {

        public string brandname { get; set; }
        public string brandcode { get; set; }
        public string market { get; set; }
        public string banktype { get; set; }
        public string markettype { get; set; }
        public string nisaflg { get; set; }
        public string shareholding { get; set; }
        public string buyprice_ave { get; set; }
        public string estprice_uni { get; set; }
        public string estprice_all { get; set; }
        public string valuation { get; set; }


        public Portfolio() {}
         
        public void setAll(string strrec)
        {

            string strrec_temp = strrec.Replace("\",\"","!");
            char delimiter = '!';
            string[] arr = strrec_temp.Split(delimiter);
            int last_idx = arr.Length - 1;

            arr[0] = arr[0].Replace("\"", "");
            arr[last_idx] = arr[last_idx].Replace("\"", "");

            try
            {
                this.brandname = arr[0];
                this.brandcode = arr[1];
                this.market = arr[2];
                this.banktype = arr[3];
                this.markettype = arr[4];
                this.nisaflg = arr[5];
                this.shareholding = arr[6];
                this.buyprice_ave = arr[7];
                this.estprice_uni = arr[8];
                this.estprice_all = arr[9];
                this.valuation = arr[10];
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

    }
}
