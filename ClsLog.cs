using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TradeApp
{
   public class ClsLog
    {
        static TextWriter Tx;
        private static Object thisLock = new Object();
        public static void WriteLog(string LogText)
        {
            try
            {
                lock (thisLock)
                {
                    Tx = new StreamWriter(Environment.CurrentDirectory + "\\AppLog.txt", true);
                    Tx.WriteLine(LogText);
                    Tx.Close();
                }
            }
            catch
            {

            }
            
        }




    }
}
