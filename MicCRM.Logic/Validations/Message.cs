using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicCRM.Logic.Validations
{
    public class Message
    {
        public Message(string code, string text, MessageType type)
        {
            Code = code;
            Text = text;
            Type = type;
        }

        public MessageType Type { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }

    }
}
