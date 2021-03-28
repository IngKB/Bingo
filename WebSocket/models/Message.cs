﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSocket.models
{
    public class Message
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
    }
}
