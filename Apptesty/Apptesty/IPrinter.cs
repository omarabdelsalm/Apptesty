using System;
using System.Collections.Generic;
using System.Text;

namespace Apptesty
{
    public interface IPrinter
    {
        void Print(string ipAddress, int port, IList<string> linesToPrint);
    }
}
