using System;
using System.Text;
using System.Collections.Generic;

namespace LRRoguelike
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output text encoding
            Console.OutputEncoding = Encoding.UTF8;

            // Instantiate classes
            Random rndm = new Random();
            Render rndr = new Render();

            rndr.StartMenu();

        }
    }
}
