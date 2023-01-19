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
    public class SendToDB : IGetDataResponse
    {
        public int SendPersonToDb(List<GetResults> persons, ILogger<Worker> logger)
        {
            DataContext cadPerson = new();
            int resultadoInsert = 0;

            try
            {
                if (persons.Count != 0)
                {
                    //foreach(var person in persons)
                    //{
                    //    cadPerson.Personagens.Add(person.Results[0]);

                    //}
                    for (int i = 0; i < persons.Count; i++)
                    {
                        cadPerson.RICKMORTY.Add(persons[i]);
                        cadPerson.SaveChanges();
                        logger.LogInformation("Personagem :" + persons[i].Name + ", inserido com sucesso !");
                        

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
