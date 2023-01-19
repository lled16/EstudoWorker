using AprendendoWorker.Models.PersonsResponse;
using AprendendoWorker.Properties.RetornaDados;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoWorker.Services.GetPersons
{
    public class GetPersons
    {

        public int GetDadosPer(ILogger<Worker> logger)
        {
            int getResponse = GetDadosPersonagens(logger);


            return getResponse;
        }

        public  int GetDadosPersonagens(ILogger<Worker> logger)
        {
            int resultadoInsert = 0;

            var externUrlPerson = "https://rickandmortyapi.com/api/character";

            var cliente = new HttpClient();

            var request = cliente.GetStringAsync(externUrlPerson);

            request.Wait();
            

            List<GetResults> response = JsonConvert.DeserializeObject<GetPersonsAPI>(request.Result).Results;


            SendToDB sendDB = new();

            try
            {
                resultadoInsert = sendDB.SendPersonToDb(response, logger);

                if(resultadoInsert == 1)
                {
                    return resultadoInsert;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw new Exception("Não foi possível inserir os personagens !");
            }



            return resultadoInsert;

        }




    }
}
