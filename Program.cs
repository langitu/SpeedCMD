using CommandLine;
using SpeedCMD;

CommandLine.Parser.Default.ParseArguments<ServerOptions, ClientOptions>(args)
  .MapResult(
    (ServerOptions opts) => RunServer(opts),
    (ClientOptions opts) => RunClient(opts),
    errs => 1);

int RunServer(ServerOptions opts)
{
  try
  {
    var server = new Server(opts.Port);
    server.Start();
    return 0;
  }
  catch (System.Exception e)
  {
    System.Console.WriteLine("Exception: {0}", e);
    return 1;
  }
}

int RunClient(ClientOptions opts)
{
  try
  {
    var client = new Client(opts.Port, opts.Host);
    client.Connect();
    return 0;
  }
  catch (System.Exception e)
  {
    System.Console.WriteLine("Exception: {0}", e);
    return 1;
  }
}

