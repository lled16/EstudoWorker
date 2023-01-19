using AprendendoWorker.DataBase;
using AprendendoWorker.Interfaces;
using AprendendoWorker.Models.PersonsResponse;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AprendendoWorker.Properties.RetornaDados
{
    public class GetDataResponse : IGetDataResponse
    {
    private readonly ILogger<GetDataResponse> _logger;

        public GetDataResponse(ILogger<GetDataResponse> logger)
        {
            _logger = logger;
        }

        public int SendPersonToDb(List<GetResults> persons)
        {
            DataContext cadPerson  = new();
            int resultadoInsert = 0;
            string T = "";
            try
            {
                if (persons.Count != 0)
                {
                    for (int i = 0; i < persons.Count; i++)
                    {
                        cadPerson.RICKMORTY.Add(persons[i]);
                        cadPerson.SaveChanges();
                        _logger.LogInformation("Personagem :" + persons[i].Name + ", inserido com sucesso !");
                        

                        if (i == persons.Count - 1)
                        {
                            resultadoInsert = 1;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.ToString());
            }

            return resultadoInsert;
        }

    }
}
