
# POC-gRPC

## Welcome to first gRCP Projects

Day 1 for first gRPC API that is proving of concept (POC) in gRPC server work with gRPC client.

---

### Introduce

> gRPC is a modern API gRPC is a modern open source high performance Remote Procedure Call (RPC) 
> that fastest transfers data  because it uses
> protocol buffers to serialize payload data as binary for transfer that
> can run in any environment such as C# node go-lang and others.

### Prerequisites

- Visual Studio Code

- C# for Visual Studio Code (latest version)

### What's Goals 

- First gRCP Server (minimal api asp.net core 6)

- First gRCP Client connected with gRCP server

### Workaround

- Open VS Code or Terminal.

- Make sure for the work with dotnet Ctl version 6. How to make sure with command in below that before stating.

```c#

dotnet --version

```

**First gRCP Server (minimal API with asp.net core 6)**

- Create gRCP project with command.

```.NET CLI

dotnet new grpc -o gRPC_server_dotnet

code -r gRPC_server_dotnet

```

- Go to path gRCP server project then run build for test error missing.

```.NET CLI

cd gRPC_server_dotnet

dotnet run build

```

- For Mac OS, Set Config Kestrel's local web server in the *Program.cs*.

```C#

using  Microsoft.AspNetCore.Hosting;

using  Microsoft.AspNetCore.Server.Kestrel.Core;

  

builder.WebHost.ConfigureKestrel(options =>

{

// Setup an HTTP/2 endpoint without TLS.

options.ListenLocalhost(5000, o => o.Protocols =

HttpProtocols.Http2);

});

```

- In above, this set up Kestrel binding port 5000 to use protocol Http2 in the local env.

- Start a project to finish your first goals.

```C#

dotnet  run

```

If you have a problem while running the project it's an issue on #1 in the Troubleshooting title.

- Done! The gRCP project is listening on <https://localhost:5000>

---

##### First gRCP Client (console application with asp.net core 6 )

- Create gRCP Client

- Go to root folder with `command : cd ..`

- Create new console project with command.

```C#

dotnet  new  console -o  gRPC_client_dotnet_6

code -r  gRPC_client_dotnet_6

```

- Go to the folder gRPC_client_dotnet_6 by ` cd gRPC_client_dotnet `

- Run this command for install package libaries.

```C#

dotnet  add  gRPC_client_dotnet_6.csproj  package  Grpc.Net.Client

dotnet  add  gRPC_client_dotnet_6.csproj  package  Google.Protobuf

dotnet  add  gRPC_client_dotnet_6.csproj  package  Grpc.Tools

```

- Create a Protos folder in the gRPC client project.

- Copy the Protos\greet.proto file from the `gRPC_server_dotnet_6` service to the Protos folder in the gRPC client project.

- Update the namespace inside the greet.proto file to the project's namespace

```C#

option  csharp_namespace = "gRPC_client_dotnet_6";

```  

- Edit the `gRPC_client_dotnet_6.csproj` project file

```C#

<ItemGroup>

<Protobuf  Include="Protos\greet.proto"  GrpcServices="Client" />

</ItemGroup>

```
  
- Run client's gRCP project with command  

```C#

dotnet  run

```

- gRCP Client'll display a message in the below example for proving to connected with gRCP server.
  
```C#

Greeting: Hello  TWer

Press  any  key  to  exit...

```

- Done.

---

### Toubleshoting

1. Take an error message "HTTP/2 over TLS is not supported on macOS due to missing ALPN support"

Issue:

- Unable to start ASP.NET Core gRPC app on macOS: The Kestrel is web server doesn't support HTTP/2 with TLS on macOS.

Solve:

- To work around this issue, you must configure Kastrel for asp.net core 6 in the *Program.cs*

```C#

using  Microsoft.AspNetCore.Hosting;

using  Microsoft.AspNetCore.Server.Kestrel.Core;

  

builder.WebHost.ConfigureKestrel(options =>

{

// Setup a HTTP/2 endpoint without TLS

options.ListenLocalhost(5000, o => o.Protocols =

HttpProtocols.Http2);

});

```

### References

- https://grpc.io/
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-6.0&tabs=visual-studio