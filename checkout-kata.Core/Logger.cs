using System;
using System.Collections.Generic;
using System.Text;

namespace checkout_kata.Core
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            // For now, just write to the standard console output.
            // In a production-ready app, the logs might be written to a server.
            System.Console.WriteLine(message);
        }

    }
}
