$v = (git describe --abbrev=0 --tags)
$p = "./bin/release/net7.0"

# window
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a x64 --os win
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a x86 --os win
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a arm64 --os win

./7z a release/$v/speedcmd-win-x64-$v.zip $p/win-x64/publish/speedcmd.exe
./7z a release/$v/speedcmd-win-x86-$v.zip $p/win-x86/publish/speedcmd.exe
./7z a release/$v/speedcmd-win-arm64-$v.zip $p/win-arm64/publish/speedcmd.exe

# window10
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a x64 --os win10
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a x86 --os win10
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a arm64 --os win10

./7z a release/$v/speedcmd-win10-x64-$v.zip $p/win10-x64/publish/speedcmd.exe
./7z a release/$v/speedcmd-win10-x86-$v.zip $p/win10-x86/publish/speedcmd.exe
./7z a release/$v/speedcmd-win10-arm64-$v.zip $p/win10-arm64/publish/speedcmd.exe

# linux
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a x64 --os linux
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a arm --os linux
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a arm64 --os linux

./7z a release/$v/speedcmd-linux-x64-$v.zip $p/linux-x64/publish/speedcmd
./7z a release/$v/speedcmd-linux-arm-$v.zip $p/linux-arm/publish/speedcmd
./7z a release/$v/speedcmd-linux-arm64-$v.zip $p/linux-arm64/publish/speedcmd
