# POC-gRPC

## Welcome to first gRCP Projects

---

### Intro

gRPC is ...

### Prerequisites

- Visual Studio Code
- C# for Visual Studio Code (latest version)

### What's Goals

- First gRCP Server (asp.net core 5)
- First gRCP Client connected with gRCP server

### Workaround

- Open VS Code or Terminal.
- Make sure for the work with dotnet ctl version 6. How to make sure with command in below that befroe stating.

```c#
dotnet --version
```

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

- Set Config Kestrel web server in an appsetting.json.

```C#
    "Kestrel": {
        "Endpoints": {
            "Http": {
                "Url": "http://*:5002"
            },
            "Https": {
                "Url": "https://*:5001"
            }
        }
   }
```

- Start project for finish your first goals.

```.NET CLI
dotnet run
```

If you have a problem while running project it's propbrary iisue on #1 in Toubleshoting title.

- Done! The gRCP project is listening on: https://localhost:5001

- Create gRCP Client

- Go to root folder with `command : cd ..`

- Create new console project  with command.
  
  ```C#
    dotnet new console -o gRPC_client_dotnet_6
    code -r gRPC_client_dotnet_6
  ```

- Go to the folder gRPC_client_dotnet_6 by ` cd gRPC_client_dotnet `

- Run this command for install package libaries.

```C#
dotnet add gRPC_client_dotnet_6.csproj package Grpc.Net.Client
dotnet add gRPC_client_dotnet_6.csproj package Google.Protobuf
dotnet add gRPC_client_dotnet_6.csproj package Grpc.Tools
```

- Create a Protos folder in the gRPC client project.
- Copy the Protos\greet.proto file from the `gRPC_server_dotnet_6` service to the Protos folder in the gRPC client project.
- Update the namespace inside the greet.proto file to the project's namespace

```C#
    option csharp_namespace = "gRPC_client_dotnet_6";
```

- Edit the `gRPC_client_dotnet_6.csproj` project file

```C#
<ItemGroup>
  <Protobuf Include="Protos\greet.proto" GrpcServices="Client" />
</ItemGroup>
```

### Toubleshoting

1. Take an error message "HTTP/2 over TLS is not supported on macOS due to missing ALPN support"

    Issue:

    - Unable to start ASP.NET Core gRPC app on macOS : The Kestrel is web server doesn't support HTTP/2 with TLS on macOS.

    Solve:

     - To work around this issue, you must configure Kastrel for asp.net core 6 in appsetting.json

     ```C#
        "Kestrel": {
        "Endpoints": {
                "Http": {
                    "Url": "http://*:5001"
                },
                "Https": {
                    "Url": "https://*:5002"
                }
            }
        }
     ```

### Reference
