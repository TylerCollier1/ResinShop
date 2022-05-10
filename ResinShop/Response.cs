using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResinShop.Core
{
    public class Response
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        private List<string> messages = new List<string>();
        public List<string> Messages => new List<string>(messages);
        public void AddMessage(string message)
        {
            messages.Add(message);
        }
    }
    public class Response<T> : Response
    {
        public T Data { get; set; }
    }
}
