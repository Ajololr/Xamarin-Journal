using System.Threading.Tasks;

namespace Lab3.FirebaseServices
{
    public interface IAuth
    {
        Task SignIn(string email, string password);

        Task<Student> SignUp(string email, string password, string firstName, string lastName, string secondName, System.DateTime birthday, string[] images);
    }
}
