using AprendendoWorker.Interfaces;
using AprendendoWorker.Models.PersonsResponse;
using AprendendoWorker.Properties.RetornaDados;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoWorker.Services.GetPersonsWorker
{       
    public class GetPersonsWorker : IGetPersonsWorker
    {
        private readonly IGetDataResponse _getDataResponse;
        private readonly ILogger<GetPersonsWorker> _logger;

        public GetPersonsWorker(IGetDataResponse getDataResponse, ILogger<GetPersonsWorker> logger)
        {
            _getDataResponse = getDataResponse;
            _logger = logger;
        }

        public int GetDadosPer()
        {
            int getResponse = GetDadosPersonagens(_logger);


            return getResponse;
        }

        public  int GetDadosPersonagens(ILogger logger)
        {
            int resultadoInsert = 0;

            var externUrlPerson = "https://rickandmortyapi.com/api/character";

            var cliente = new HttpClient();

            var request = cliente.GetStringAsync(externUrlPerson);

            request.Wait();
            

            List<GetResults> response = JsonConvert.DeserializeObject<GetPersonsAPI>(request.Result).Results;


           

            try
            {
                resultadoInsert = _getDataResponse.SendPersonToDb(response);

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
