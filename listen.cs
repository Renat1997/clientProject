using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;

namespace RenatGaynullin
{
    class listen
    {
        private static TcpClient client;

        public static void lis(Form1 form,CancellationToken token)
        {
            form.Send += new Form1.SendState(showMes);
            TcpListener server = null;
            try
            {
                var port = form.GetPort;
                int portInt = 0;
                try
                {

                    portInt = Convert.ToInt32(port); // конвертация из стринг в инт


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }



                IPAddress adr = IPAddress.Parse("127.0.0.1");

                server = new TcpListener(adr, portInt);

                server.Start();

                CancellationTokenSource tokenSource = new CancellationTokenSource();
                Task.Run(() => connectioCheck(tokenSource.Token));

                

                while (!token.IsCancellationRequested)
                {
                    if (client == null || !client.Connected)
                        client = server.AcceptTcpClient();

                    Thread.Sleep(1);
                }
                
                
                
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
               server.Stop();
            }
        }
        public static  void connectioCheck(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (client != null && client.Connected == true)
                    {
                        NetworkStream stream = client.GetStream();
                        byte[] msg = System.Text.Encoding.Unicode.GetBytes(string.Empty);
                        stream.Write(msg, 0, msg.Length);
                    }
                }
                catch
                {
                    client.Close();
                }
               
                //Task.Delay(TimeSpan.FromSeconds(10));
                Thread.Sleep(10000);
            }
        }


        public static void showMes(string state)
        {
          
                try
                {



                    if (client != null && client.Connected == true)
                    {
                        NetworkStream stream = client.GetStream();
                        byte[] msg = System.Text.Encoding.Unicode.GetBytes(state);
                        stream.Write(msg, 0, msg.Length);
                    }
                }

                catch
                {

                }
            
        }
    }
    
}