using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using tutorial_2.Models;

namespace tutorial_2
{
    public class CustomComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return StringComparer
                .InvariantCultureIgnoreCase
                .Equals($"{x.FirstName} {x.Email} {x.LastName} {x.StudentIndex}",
                        $"{y.FirstName} {y.Email} {y.LastName} {y.StudentIndex}");
        }

        public int GetHashCode(Student obj)
        {
            return StringComparer
                .InvariantCultureIgnoreCase
                .GetHashCode($"{obj.FirstName} {obj.Email} {obj.LastName} {obj.StudentIndex}");
        }
    }
}
