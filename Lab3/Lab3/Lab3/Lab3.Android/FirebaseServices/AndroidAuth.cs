using Firebase.Auth;
using Lab3.Droid.FirebaseServices;
using Lab3.FirebaseServices;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidAuth))]
namespace Lab3.Droid.FirebaseServices
{
    public class AndroidAuth : IAuth
    {
        public async Task SignIn(string email, string password)
        {
                await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
        }

        public async Task<Student> SignUp(string email, string password, string firstName, string lastName, string secondName, DateTime birthday, string[] images)
        {
                await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                return new Student { FirstName = firstName, LastName = lastName, SecondName = secondName, Birthday = birthday, Images = images};
            
        }
    }
}