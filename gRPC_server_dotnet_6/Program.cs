using gRPC_server_dotnet_6.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

builder.WebHost.ConfigureKestrel(options =>
             {
                 // Setup a HTTP/2 endpoint without TLS.
                 options.ListenLocalhost(5000, o => o.Protocols =
                     HttpProtocols.Http2);
             });

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();


app.MapGet("/", () =>
{
    return "Communication with gRPC endpoints";
});

app.Run();
