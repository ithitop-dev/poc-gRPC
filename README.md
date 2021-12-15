# POC-gRPC

## Welcome to first gRCP Projects

---

### Intro

gRPC is ...

### Prerequisites

- Visual Studio Code
- C# for Visual Studio Code (latest version)
- .NET 6.0 SDK

### What's Goals

- First gRCP Server (asp.net 6 using gRCP Protocal)
- First gRCP Client connected with gRCP server (asp.net 6 console application)

### Workaround

- Open VS Code or Terminal.
- Make sure for the work with dotnet ctl version 6. How to make sure with command in below that befroe stating.

```c#
dotnet --version
```

- Create gRCP project with command.

```.NET CLI
dotnet new grpc -o gRPC_server_dotnet_6
code -r gRPC_server_dotnet_6
```

- Go to path gRCP server project then Run build for test error missing.  

```.NET CLI
cd gRPC_server_dotnet_6
dotnet run build
```

- Start project for finish your first goals.

```.NET CLI
dotnet run
```

If you have a problem while running project it's propbrary iisue on #1 in Toubleshoting title.


### Toubleshoting

1. Take an error message "HTTP/2 over TLS is not supported on macOS due to missing ALPN support" 

    issue:

    - Unable to start ASP.NET Core gRPC app on macOS : The Kestrel is web server doesn't support HTTP/2 with TLS on macOS.

    solve:

     - To work around this issue, you must configure Kastrel in appsetting.json

     ```C#
        "Kestrel": {
            "gRPC": {
            "Url": "http://localhost:5000",
            "Protocols": "Http2"
            }
        }
     ```

### Reference
