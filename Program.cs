using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Azure.Communication.Email;
using EmailProvider.Services;


var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services => 
    {
        services.AddSingleton<EmailClient>(new EmailClient(Environment.GetEnvironmentVariable("CommunicationServices")));
        services.AddSingleton<IEmailService, EmailService>();

    })
    .Build();

host.Run();
