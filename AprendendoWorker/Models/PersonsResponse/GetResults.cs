using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoWorker.Models.PersonsResponse
{
    public class GetResults
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Gender { get; set; }
        public string Species { get; set; }
    }
}
