using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemoCSharpDemo
{
   public interface IDepatrmentRepo
    {
        public IEnumerable<Department> GetAllDeparments();
        public void InsertDepartment(string newName);
    }
}
