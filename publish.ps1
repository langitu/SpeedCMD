# window
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a x64 --os win -o release/win-x64
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a x86 --os win -o release/win-x86
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a arm64 --os win -o release/win-arm64

./7z a release/speedcmd-win-x64-$(git describe --abbrev=0 --tags).zip release/win-x64/speedcmd.exe
./7z a release/speedcmd-win-x86-$(git describe --abbrev=0 --tags).zip release/win-x86/speedcmd.exe
./7z a release/speedcmd-win-arm64-$(git describe --abbrev=0 --tags).zip release/win-arm64/speedcmd.exe

# window10
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a x64 --os win10 -o release/win10-x64
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a x86 --os win10 -o release/win10-x86
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a arm64 --os win10 -o release/win10-arm64

./7z a release/speedcmd-win10-x64-$(git describe --abbrev=0 --tags).zip release/win10-x64/speedcmd.exe
./7z a release/speedcmd-win10-x86-$(git describe --abbrev=0 --tags).zip release/win10-x86/speedcmd.exe
./7z a release/speedcmd-win10-arm64-$(git describe --abbrev=0 --tags).zip release/win10-arm64/speedcmd.exe

# linux
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a x64 --os linux -o release/linux-x64
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a arm --os linux -o release/linux-arm
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a arm64 --os linux -o release/linux-arm64

./7z a release/speedcmd-linux-x64-$(git describe --abbrev=0 --tags).zip release/linux-x64/speedcmd
./7z a release/speedcmd-linux-arm-$(git describe --abbrev=0 --tags).zip release/linux-arm/speedcmd
./7z a release/speedcmd-linux-arm64-$(git describe --abbrev=0 --tags).zip release/linux-arm64/speedcmd
