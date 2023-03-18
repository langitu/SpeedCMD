
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SpeedCMD;

public class Server
{
  public Server(int port)
  {
    Port = port;
    _ipe = new IPEndPoint(_ip, port);
  }

  private const string _sendStr = "ok!Client send message successful!";
  private static byte[] _sendBytes = Encoding.ASCII.GetBytes(_sendStr);
  private static byte[] _recvBytes = new byte[1024];
  private const string _host = "0.0.0.0";
  private static IPAddress _ip = IPAddress.Parse(_host);

  public int Port { get; }

  private IPEndPoint _ipe;

  public void Start()
  {
    var cancellationTokenSource = new CancellationTokenSource();
    var s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    s.Bind(_ipe);
    s.Listen(0);
    Console.WriteLine("等待客户端连接");
    try
    {
      do
      {
        var temp = s.Accept();
        Console.WriteLine("建立连接 {0}>{1}", temp.LocalEndPoint, temp.RemoteEndPoint);
        var task = Task.Factory.StartNew(() =>
         {
           try
           {
             do
             {
               temp.Receive(_recvBytes, _recvBytes.Length, 0);
               temp.Send(_sendBytes, _sendBytes.Length, 0);
             } while (true);
           }
           catch (SocketException e)
           {
             Console.WriteLine("SocketException:{0}", e);
           }
           finally
           {
             temp.Close();
           }
         }, cancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
      } while (true);
    }
    finally
    {
      cancellationTokenSource.Cancel(true);
      s.Close();
    }
  }
}
