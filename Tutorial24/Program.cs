﻿using System;
using System.Collections.Generic;
using System.Linq;
using LanguageExt;
using LanguageExt.DataTypes.Serialisation;

namespace Tutorial24
{
    // This tutorial shows you how you can transform a List of Eithers, effectively doing a Map on each either in the list, and this Bi variety allows you to specify how make provision to map/transform both types
    
    class Program
    {
        static void Main(string[] args)
        {
            Either<int, string> intOrString1 = "Stuart";
            Either<int, string> intOrString2 = "Jenny";
            Either<int, string> intOrString3 = "Bruce";
            Either<int, string> intOrString4 = "Bruce";
            Either<int, string> intOrString5 = 66;

            IEnumerable<Either<int, string>> listOfEithers = new Either<int, string>[] { intOrString1, intOrString2, intOrString3, intOrString4, intOrString5 };

            // Extract right values from the eithers in the list and run this function to get them.
            // note if there is no right value for the either being inspected, this function is not run
            listOfEithers.IterT(rightString => Console.WriteLine($"{rightString}"));
        }
        
    }      
}
