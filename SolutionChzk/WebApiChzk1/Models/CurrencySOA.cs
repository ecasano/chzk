﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiChzk1.Transfer;

namespace WebApiChzk1.Models
{
    public partial class Currency
    {
        //listado de monedas
        public static IEnumerable<Currencydt> ListarMonedas()
        {
            chzkEntities db = new chzkEntities();
            var list = from b in db.Currency
                       select new Currencydt()
                       {
                           currency1 = b.currency1,
                           description = b.description
                          

                       };
            return list;

        }

        //listado de monedas por pais
        public static IEnumerable<Currencydt> ListarMonedasXpais(string pais)
        {
            chzkEntities db = new chzkEntities();
            var list = from b in db.Currency.Where(t => t.country == pais)
                       select new Currencydt()
                       {
                           currency1 = b.currency1,
                           description = b.description,
                           sign = b.sign
                       };
            return list;

        }

    }
}