using System;
using System.Collections.Generic;
using tutorial_3.Models;

namespace tutorial_3.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
    }
}
