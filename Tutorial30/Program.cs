﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using LanguageExt;
using LanguageExt.DataTypes.Serialisation;

namespace Tutorial30
{

    class Program
    {
        static void Main(string[] args)
        {
            
            var resultB = DivideBy1(225, 5);

            var result2 = Add5ToIt(resultB);

            // Now we can continue with the knowledge that result2 as 5 added to it or not (and everyone else will do that too:)

            var result = PerformPensionCalculations(result2);

            if (result.IsNone)
            {
                Console.WriteLine($"Could not determine your pension, because invalid input was used");
            }

            if (result.IsSome)
            {
                var pension = result.Match(Some: i => i, None: 0);
                Console.WriteLine($"Your pension is '{pension}'");
            }

        }

        static Option<int> PerformPensionCalculations(Option<int> input)
        {
            // Extract, Validate and transform it using Map
            return input.Map(validInput => CalculateYourPension(validInput));
            // we can call a normal function (non monad returning or accepting) inside a Map or Bind
        }


        static int CalculateYourPension(int input)
        {
            return (input * 3) / 26;
        }

        static int DivideBy(int thisNumber, int dividedByThatNumber)
        {
            if (dividedByThatNumber == 0)
                return 0;
            return thisNumber / dividedByThatNumber;
        }

        static Option<int> DivideBy1(int thisNumber, int dividedByThatNumber)
        {
            if (dividedByThatNumber == 0)
            {
                Option<int> t = Option<int>.None;
                return t;
            }

            return thisNumber / dividedByThatNumber;
        }

        static Option<int> Add5ToIt(Option<int> input)
        {
         // View a Bind/Map as 'Try to add 5' if the input is valid ie not a None
           return input.Bind(validInput =>
           {
               Option<int> option = validInput + 5;
               return option;
           }); 
        }
    }      
}
