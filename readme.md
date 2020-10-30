## Good to know
If you have scaffolding issues, it's maybe the SDK version. Here's the command to downgrad it in linux to a stable version (as far as I tested it)
```bash
sudo apt-get remove dotnet-sdk-3.1 --purge
sudo apt-get install dotnet-sdk-3.1=3.1.302-1
sudo apt-mark hold dotnet-sdk-3.1
dotnet tool uninstall -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-aspnet-codegenerator --version 3.1.3
```

`dotnet --info` should render

```
NET Core SDK (reflecting any global.json):
 Version:   3.1.302
 Commit:    41faccf259

Runtime Environment:
 OS Name:     ubuntu
 OS Version:  20.04
 OS Platform: Linux
 RID:         ubuntu.20.04-x64
 Base Path:   /usr/share/dotnet/sdk/3.1.302/

Host (useful for support):
  Version: 3.1.9
  Commit:  774fc3d6a9

.NET Core SDKs installed:
  3.1.302 [/usr/share/dotnet/sdk]

.NET Core runtimes installed:
  Microsoft.AspNetCore.App 3.1.9 [/usr/share/dotnet/shared/Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 3.1.9 [/usr/share/dotnet/shared/Microsoft.NETCore.App]
```


## "In case of emergency break glass" commands
dotnet restore

dotnet build