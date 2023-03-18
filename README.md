# SpeedCMD

命令行测速、测延迟工具

## 发布项目

```sh
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a x64 --os win
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a x64 --os win10
dotnet publish -c Release -p:PublishSingleFile=true --self-contained false -a arm64 --os linux
# dotnet publish -c Release --runtime win10-x64 --self-contained false -p:PublishSingleFile=true
```

### 参考文档

- [dotnet publish 命令文档](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-publish)
- [发布为单文件](https://learn.microsoft.com/en-us/dotnet/core/deploying/single-file/overview?tabs=cli)
- [不同平台的运行时](https://learn.microsoft.com/zh-cn/dotnet/core/rid-catalog)
