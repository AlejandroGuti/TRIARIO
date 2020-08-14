using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto1
{
    class PefectNumbers
    {
        public string perfects { get; set; }
        public PefectNumbers()
        {
            perfects = null;
            
        }
        public PefectNumbers(string perfectsIn)
        {
            perfects = perfectsIn;
            evaluar(perfects);
        }



        private void evaluar(string Limit)
        {
            perfects = null;

            int sum = 0;
            int limite = Convert.ToInt32(Limit);
            for (int i = 1; i <= limite; i++)
            {
                for(int j =i; j >= 1; j--)
                {
                    if (i % j == 0) { 
                        sum = sum + j ;
                    }
                }
                
                if (i == (sum -i)) { perfects = perfects + i.ToString()+"\t"; }
                sum = 0;
            }
            return;
            
        }
    }
}
