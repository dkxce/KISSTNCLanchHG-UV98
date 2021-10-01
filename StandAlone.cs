using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Web;

namespace Executable
{
    class StandAlone
    {
        static void Main(string[] args)
        {
            // TEST TCP/IP
            ax25kiss.KISSTNC kiss = new ax25kiss.KISSTNC("127.0.0.1:8100");
            //ax25kiss.KISSTNC kiss = new ax25kiss.KISSTNC("COM2:9600");
            kiss.onPacket = new ONPCKT();
            //kiss.KISSInit = "KISS ON\nRESET\n";
            kiss.Debug = true;
            kiss.Start();
            System.Threading.Thread.Sleep(500);
            kiss.Send("VOLGA", "OKOPOK", new string[] { "WIDE1-1", "WIDE2-2" }, "!5533.00ND03733.00E&RNG0001/A=000198 400 Voice 433.45MHz");
            Console.ReadLine();
            kiss.Stop();

            //kiss_test.KISSTNC.Test();
        }        
    }

    public class ONPCKT : ax25kiss.AX25Handler
    {
        public void handlePacket(ax25kiss.Packet packet)
        {
            Console.WriteLine(">> " + packet.ToString());
        }
    }  
}
