using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiChzk1.Models
{
    public partial class Country
    {
        chzkEntities db = new chzkEntities();
        Country country = db.Country.Find();

        //  alumno alumno = db.alumnos.Find(this.id);
        //  alumno.edad += 1;
        //  db.Entry(alumno).State = EntityState.Modified;
        //  db.SaveChanges();

    }
}