using CommandLine;

namespace SpeedCMD;

[Verb("server", HelpText = "启动服务端")]
public class ServerOptions
{
  [Option('p', "port", Default = 22, Required = false, HelpText = "设置服务器监听端口")]
  public int Port { get; set; }
}

[Verb("client", HelpText = "启动客户端")]
public class ClientOptions
{
  [Option('p', "port", Default = 22, Required = false, HelpText = "设置服务器端口")]
  public int Port { get; set; }
  [Option('h', "host", Default = "127.0.0.1", Required = false, HelpText = "设置服务器IP地址")]
  public string Host { get; set; } = string.Empty;
}
