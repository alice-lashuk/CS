using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using tutorial_2.Models;

namespace tutorial_2
{
    public class CustomComparerStudies : IEqualityComparer<ActiveStudies>
    {
        public bool Equals([AllowNull] ActiveStudies x, [AllowNull] ActiveStudies y)
        {
            return StringComparer
                .InvariantCultureIgnoreCase
                .Equals($"{x.Name}{x.Number}",
                        $"{y.Name}{y.Number}");
        }

        public int GetHashCode([DisallowNull] ActiveStudies obj)
        {
            return StringComparer
                 .InvariantCultureIgnoreCase
                 .GetHashCode($"{obj.Name} {obj.Number}");
        }
    }
}