using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp8
{
    internal delegate string RuleDelegate(int current, string previous);

    internal class Program
    {
        private static void Main()
        {
            var rules = new List<RuleDelegate>
            {
                (i, prev) => i % 3 == 0 ? prev + "Fizz" : prev,
                (i, prev) => i % 5 == 0 ? prev + "Buzz" : prev,
                (i, prev) => string.IsNullOrEmpty(prev) ? i.ToString() : prev
            };

            var someNumbers = Enumerable.Range(1, 100);

            var result = someNumbers.Aggregate(
                string.Empty,
                (previous, current) =>
                {
                    var numberResult = previous + (string.IsNullOrEmpty(previous) ? string.Empty : ", ") + rules.Aggregate("", 
                        (prevNumResult, ruleCallback) => ruleCallback(current, prevNumResult));
                    return numberResult;
                });

            Console.Write(result);
            Console.ReadKey();
        }
    }
}