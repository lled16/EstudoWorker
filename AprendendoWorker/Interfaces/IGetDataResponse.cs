using AprendendoWorker.Models.PersonsResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoWorker.Interfaces
{
    public interface  IGetDataResponse
    {
        public int SendPersonToDb(List<GetResults> persons, ILogger<Worker> logger); 
    }
}
