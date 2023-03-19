using System.CommandLine;
using SpeedCMD;

var rootCommand = new RootCommand("网络测速命令行工具");
var serverCommand = new Command("server", "使用服务端");
var clientCommand = new Command("client", "使用客户端");

rootCommand.AddCommand(serverCommand);
rootCommand.AddCommand(clientCommand);

// common options
var portOption = new Option<int>("--port", "设置程序监听或访问的端口");
portOption.AddAlias("-p");
portOption.SetDefaultValue(22);
portOption.AddValidator(result =>
{
  if (result.GetValueForOption(portOption) is not > 0 and < 65536)
  {
    result.ErrorMessage = "范围必须在[1-65535]之间";
  }
});

// server options
//...

// client options
var hostOption = new Option<string>("--host", "设置远程主机或IP");
hostOption.SetDefaultValue("127.0.0.1");

serverCommand.AddOption(portOption);
clientCommand.AddOption(portOption);
clientCommand.AddOption(hostOption);

serverCommand.SetHandler(DoServerCommand, portOption);
clientCommand.SetHandler(DoClientCommand, portOption, hostOption);

return await rootCommand.InvokeAsync(args);

void DoServerCommand(int port)
{
  var server = new Server(port);
  server.Start();
}

void DoClientCommand(int port, string host)
{
  var client = new Client(port, host);
  client.Connect();
}
