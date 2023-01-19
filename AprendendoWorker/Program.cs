using AprendendoWorker;
using AprendendoWorker.Interfaces;
using AprendendoWorker.Properties.RetornaDados;
using AprendendoWorker.Services;
using AprendendoWorker.Services.GetPersonsWorker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {


        services.AddHostedService<Worker>()
        .AddSingleton<IGetDataResponse, GetDataResponse>()
        .AddSingleton<IGetPersonsWorker, GetPersonsWorker>();
    })
    .Build();

await host.RunAsync();
