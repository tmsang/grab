using System;
using System.Threading;

namespace tmsang.batchjob
{
    public class Program
    {
        const int PERIOD_MAX_WAITING = 3;   // Khach cho toi da 3 phut
        const int CANCEL_BY_SYSTEM = 13;    // System huy khi qua 3 phut  

        static void Main(string[] args)
        {                                 
            var mysqlConnect = new MySQLConnect();

            while (1 == 1)
            {
                Thread.Sleep(TimeSpan.FromSeconds(10));

                OnAction(mysqlConnect);
            }            
        }        

        public static void OnAction(MySQLConnect connect) {
            var sql = @$"update r_orders RO, r_requests RR
                            set RO.Status = {CANCEL_BY_SYSTEM}
                            where 
                                RO.Id = RR.Id 
                                AND RO.Status in (1, 2) 
                                AND (
                                    (TIME_TO_SEC(NOW()) - TIME_TO_SEC(RR.RequestDateTime))/60 >= {PERIOD_MAX_WAITING}
                                    OR    
                                    (TIME_TO_SEC(NOW()) - TIME_TO_SEC(RR.RequestDateTime))/60 < 0     
                                )";

            connect.Update(sql);
        }
    }
}
