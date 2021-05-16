using Android.Gms.Extensions;
using Android.Runtime;
using Firebase;
using Firebase.Firestore;
using Java.Util;
using Lab3.Droid.FirebaseServices;
using Lab3.FirebaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidFirestore))]
namespace Lab3.Droid.FirebaseServices
{
    public class AndroidFirestore : IFirestore
    {
        private static FirebaseFirestore firestore = FirebaseFirestore.GetInstance(FirebaseApp.Instance);
        public async Task Add(Student student)
        {
            DateTime epoch = DateTime.UnixEpoch;

            TimeSpan ts = student.Birthday.Subtract(epoch);

            var docRef = firestore.Collection("group mates").Document();
                var hashMap = new HashMap();
                hashMap.Put("firstName", student.FirstName);
                hashMap.Put("lastName", student.LastName);
                hashMap.Put("secondName", student.SecondName);
                hashMap.Put("birthday", new Timestamp(new Date(Convert.ToInt64(ts.TotalMilliseconds))));
                hashMap.Put("longitude", student.Longitude.ToString());
                hashMap.Put("latitude", student.Latitude.ToString());
                hashMap.Put("videoUrl", student.Video);
                hashMap.Put("images", new ArrayList(student.Images));
                await docRef.Set(hashMap);

                student.Id = docRef.Id;
           
        }

        public async Task<List<Student>> GetAll()
        {
            var docsRef = (QuerySnapshot)await firestore.Collection("group mates").Get();

            var students = docsRef.Documents.Select(d => GetStudentFromSnapshot(d));

            return students.ToList();
        }

        public async Task Update(Student student)
        {
            DateTime epoch = DateTime.UnixEpoch;

            TimeSpan ts = student.Birthday.Subtract(epoch);
            var docRef = firestore.Collection("group mates").Document(student.Id);
            var hashMap = new HashMap();

            hashMap.Put("firstName", student.FirstName);
            hashMap.Put("lastName", student.LastName);
            hashMap.Put("secondName", student.SecondName);
            hashMap.Put("birthday", new Timestamp(new Date(Convert.ToInt64(ts.TotalMilliseconds))));
            hashMap.Put("longitude", student.Longitude.ToString());
            hashMap.Put("latitude", student.Latitude.ToString());
            hashMap.Put("videoUrl", student.Video);
            hashMap.Put("images", new ArrayList(student.Images));
            await docRef.Set(hashMap);
        }

        private static Student GetStudentFromSnapshot(DocumentSnapshot doc)
        {
            return new Student()
            {
                Id = doc.Id,
                FirstName = doc.GetString("firstName"),
                LastName = doc.GetString("lastName"),
                SecondName = doc.GetString("secondName"),
                Birthday = new DateTime(),
                Latitude = doc.GetString("latitude") == "" ? 0 : Double.Parse( doc.GetString("latitude")),
                Longitude = doc.GetString("longitude") == "" ? 0 : Double.Parse(doc.GetString("longitude")),
                Video = doc.GetString("videoUrl"),
                Images = doc.Get("images").JavaCast<ArrayList>()!.ToArray()!.Select(o => o.ToString()).ToArray()
            };
        }
    }
}