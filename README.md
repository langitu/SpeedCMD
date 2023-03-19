# SpeedCMD

命令行测速、测延迟工具

## 使用方法

### 1. 下载对应平台的可执行文件压缩包并解压缩

[release](https://github.com/langitu/SpeedCMD.git)

### 2. 启动 server 端

> 以 window 平台为例

```sh
# 默认监听22端口
./speedcmd server

# 或者指定端口
./speedcmd server -p 8080
```

### 3. 客户端测试

> 以 window 平台为例

```sh
# 默认访问 localhost:22
./speedcmd client

# 也可修改host和port
./speedcmd client --host localhost -p 22
```

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
