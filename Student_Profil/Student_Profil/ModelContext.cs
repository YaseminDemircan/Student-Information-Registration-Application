using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Student_Profil
{
    public class ModelContext:DbContext
    {
        public ModelContext() : base("name=cn") { }
        public DbSet<Student> StudentList { get; set; }
    }
}
