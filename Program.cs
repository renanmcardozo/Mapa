﻿using Mapas;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

//Serviços da Aplicação
builder.Services.AddSingleton<IProvedorMapa, GoogleMaps>();

using var host = builder.Build();

MinhaAplicacao(host.Services);

host.Run();
return;

void MinhaAplicacao(IServiceProvider servicos)
{
    var provedorMapas = servicos.GetService(typeof(IProvedorMapa)) as IProvedorMapa;
    
    Console.WriteLine(provedorMapas.NomeProvedor);
    Console.WriteLine(provedorMapas.Rota(origem:"IFSP", destino:"Casa"));
}