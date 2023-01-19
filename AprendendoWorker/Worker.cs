using AprendendoWorker.DataBase;
using AprendendoWorker.Interfaces;
using AprendendoWorker.Models.PersonsResponse;
using AprendendoWorker.Properties.RetornaDados;
using AprendendoWorker.Services.GetPersonsWorker;
using Azure.Messaging;
using Newtonsoft.Json;

namespace AprendendoWorker
{
    public class Worker : BackgroundService
    {
        public  ILogger<Worker> _logger;
        public  IGetPersonsWorker _getPersonsWorker;

        public Worker(ILogger<Worker> logger, IGetPersonsWorker getPersonsWorker)
        {   
            _getPersonsWorker= getPersonsWorker;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker iniciado em: {time}", DateTimeOffset.Now);

                try
                {

                    int cadastroPersonages = _getPersonsWorker.GetDadosPer();
                }catch(Exception ex) 
                {
                    new Exception(message: ex.ToString());
                }

                await Task.Delay(10000, stoppingToken);

            }
            
        }




        public string SendPersonToDb(List<GetResults> persons)
        {
            DataContext cadPerson = new();
            string resultadoInsert = "";

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
                        _logger.LogInformation("Personagem :" + persons[i].Name + ", inserido com sucesso !");

                   
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