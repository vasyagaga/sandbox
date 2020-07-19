﻿using System;
using EasyNetQ;
using Message;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                var input = "";
                Console.WriteLine("Enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.PubSub.Publish(new EventMessage
                    {
                        Text = input
                    });
                }
            }
        }
    }
}