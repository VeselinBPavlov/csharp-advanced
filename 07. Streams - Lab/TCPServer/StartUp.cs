namespace TCPServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var buffer = new byte[4096];
            var port = 3080;
            var listener = new TcpListener(IPAddress.Loopback, port);

            listener.Start();
            Console.WriteLine($"TCP Server listening on port {port}...");

            while (true)
            {
                using (var stream = listener.AcceptTcpClient().GetStream())
                {
                    var readBytes = stream.Read(buffer, 0, buffer.Length);

                    while (readBytes != 0)
                    {
                        Console.Write(Encoding.UTF8.GetString(buffer, 0, readBytes));
                        readBytes = stream.Read(buffer, 0, buffer.Length);
                    }
                    
                    Console.WriteLine();
                }
            }
        }
    }
}
