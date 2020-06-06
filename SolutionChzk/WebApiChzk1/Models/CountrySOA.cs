using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiChzk1.Transfer;

namespace WebApiChzk1.Models
{

    public partial class Country
    {
        
        public static IEnumerable<Countrydt> ListarPaises()
        {
            chzkEntities db = new chzkEntities();
            var list = from b in db.Country
                       select new Countrydt()
                       {
                           country1 = b.country1,
                           description = b.description,
                           timezone = b.timezone

                       };
            return list;

        }
    }
}