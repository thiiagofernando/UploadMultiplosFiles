using System.Collections.Generic;
using System.Web;

namespace UploadMultiplosFiles.Models
{
    public class Files
    {
        public IEnumerable<HttpPostedFileBase> Arquivo { get; set; }
    }
}