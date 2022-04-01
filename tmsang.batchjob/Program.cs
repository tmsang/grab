using System;
using System.Threading;

namespace tmsang.batchjob
{
    public class Program
    {
        /*=========================================
         * STATUS:
         
            Pending = 1,
            Accepted = 2,
            Started = 3,        
            Ended = 4,
            Evaluation = 5,

            CancelByUser = 10,
            CancelByDriver = 11,
            CancelByAdmin = 12,
            CancelBySystem = 13
        =========================================*/

        const int PERIOD_MAX_WAITING = 3;   // Khach cho toi da 3 phut
        const int CANCEL_BY_SYSTEM = 13;    // System huy khi qua 3 phut  

        const int STATUS_Pending = 1;

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
                                AND RO.Status in ({STATUS_Pending}) 
                                AND (
                                    (TIME_TO_SEC(NOW()) - TIME_TO_SEC(RR.RequestDateTime))/60 >= {PERIOD_MAX_WAITING}
                                    OR    
                                    (TIME_TO_SEC(NOW()) - TIME_TO_SEC(RR.RequestDateTime))/60 < 0     
                                )";

            connect.Update(sql);
        }
    }
}
