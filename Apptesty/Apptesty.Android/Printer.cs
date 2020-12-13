using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Xamarin.Forms;

[assembly:Dependency(typeof(Apptesty.Droid.Printer))]
namespace Apptesty.Droid
{
    class Printer : IPrinter
    {
        public void Print(string ipAddress, int port, IList<string> linesToPrint)
        {
            // Create a socket object
            Socket pSocket = new Socket(SocketType.Stream, ProtocolType.IP);

            // Connect to the printer
            pSocket.Connect(ipAddress, port);

            List<byte> outputList = new List<byte>();
            foreach (string txt in linesToPrint)
            {
                // Convert the strings to list of bytes
                outputList.AddRange(System.Text.Encoding.UTF8.GetBytes(txt));
                // Add ECS/POS Print and line feed command
                outputList.Add(0x0A); ;
            }

            // Send the command to the printer
            pSocket.Send(outputList.ToArray());

            // Close the connection once done
            pSocket.Close();
        }
    }
}