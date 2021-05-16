using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.FirebaseServices
{
    public interface IFirestore
    {
        Task<List<Student>> GetAll();

        Task Add(Student student);

        Task Update(Student student);
    }
}
