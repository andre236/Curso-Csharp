using System;
using StringBuilderEnumEcomposicao.Entities;

namespace StringBuilderEnumEcomposicao
{
    class Program
    {
        static void Main(string[] args)
        {
            Comment c1p1 = new Comment("Have a nice trip!");
            Comment c2p1 = new Comment("This Awesome!");
            Comment c1p2 = new Comment("Good night!");
            Comment c2p2 = new Comment("May the force with you!");

            Post post1 = new Post("Traveling to New Zealand", DateTime.Parse("21/06/2018 13:05:44"), "I'm going to visit this wonderful country!", 12);
            Post post2 = new Post("Good night, Guys!", DateTime.Parse("28/06/2018 23:14:19"), "See you tomorrow", 5);

            post1.AddCommemt(c1p1);
            post1.AddCommemt(c2p1);
            post2.AddCommemt(c1p2);
            post2.AddCommemt(c2p2);

            Console.WriteLine(post1);
            Console.WriteLine(post2);
           

        }
    }
}
