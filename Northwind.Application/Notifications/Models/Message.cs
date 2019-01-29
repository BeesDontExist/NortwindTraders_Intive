﻿namespace Northwind.Application.Notifications.Models
{
    public class Message
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Password { get; set; }
    }
}