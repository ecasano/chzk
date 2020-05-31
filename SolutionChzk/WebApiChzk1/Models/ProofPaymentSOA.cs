using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiChzk1.Transfer;

namespace WebApiChzk1.Models
{
    public partial class ProofPayment
    {

        public static IEnumerable<ProofPaymentdt> ComprobantedePago()
        {
            chzkEntities db = new chzkEntities();
            var list = from b in db.ProofPayment
                       select new ProofPaymentdt()
                       {
                           proofPayment1 = b.proofPayment1
                           

                       };
            return list;
        }
    }
}