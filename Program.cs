using System;
using System.Linq;

namespace DapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var resultsModel = new ResultsModel();
            var results = resultsModel.GetResults();

            Console.ReadKey();
         }
    }
}
