using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SpeedCMD;

public class Client
{
  public Client(int port, string host)
  {
    Port = port;
    Host = host;
    _ip = Dns.GetHostAddresses(host).First();
    _ipe = new IPEndPoint(_ip, Port);
  }

  private IPAddress _ip;
  private IPEndPoint _ipe;
  private static byte[] _sendBytes = Encoding.ASCII.GetBytes("hello!This is a socket test");
  private static byte[] _recvBytes = new byte[1024];

  public int Port { get; }
  public string Host { get; }

  public void Connect()
  {
    var stopwatch = new Stopwatch();
    try
    {
      var c = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
      c.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);
      Console.WriteLine("连接中...");
      stopwatch.Restart();
      c.Connect(_ipe);
      stopwatch.Stop();
      System.Console.WriteLine($"连接成功！耗时：{stopwatch.ElapsedMilliseconds}ms");

      var list = new List<long>(10);
      for (int i = 0; i < list.Capacity; i++)
      {
        stopwatch.Restart();
        c.Send(_sendBytes, _sendBytes.Length, 0);
        c.Receive(_recvBytes, _recvBytes.Length, 0);
        stopwatch.Stop();
        System.Console.WriteLine($"{i + 1} 收发消息耗时：{stopwatch.ElapsedMilliseconds}ms");
        list.Add(stopwatch.ElapsedMilliseconds);
        Thread.Sleep(100);
      }
      c.Close();
      list.Sort();
      list.RemoveAt(list.Count - 1);
      list.RemoveAt(0);
      System.Console.WriteLine($"平均耗时：{Math.Round(list.Average(), 2)}ms");
    }
    catch (ArgumentNullException e)
    {
      Console.WriteLine("argumentNullException: {0}", e);
    }
    catch (SocketException e)
    {
      Console.WriteLine("SocketException:{0}", e.Message);
    }
  }
}