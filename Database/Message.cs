using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }

    }
}
    