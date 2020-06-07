using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiChzk1.Transfer;

namespace WebApiChzk1.Models
{
    public partial class Mode
    {
        public static IEnumerable<Modedt> MododeEnvio()
        {
            chzkEntities db = new chzkEntities();
            var list = from b in db.Mode
                       select new Modedt()
                       {
                           mode1 = b.mode1,
                           description = b.description,
                           fee = b.fee

                       };
            return list;
        }
    }
}