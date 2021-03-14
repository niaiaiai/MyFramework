using System;

namespace MyEmail
{
    public class EmailOptions
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public bool EnableSsl { get; set; }
    }
}
