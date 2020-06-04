using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiChzk1.Transfer;

namespace WebApiChzk1.Models
{
    public partial class DocumentType
    {
        //listado de tipos de documentos
        public static IEnumerable<DocumentTypedt> ListarTipoDocumento()
        {
            chzkEntities db = new chzkEntities();
            var list = from b in db.DocumentType
                       select new DocumentTypedt()
                       {
                           documentType1 = b.documentType1,
                           description = b.description

                       };
            return list;

        }

    }
}