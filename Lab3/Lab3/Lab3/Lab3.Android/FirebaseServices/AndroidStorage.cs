using Android.Gms.Extensions;
using Lab3.Droid.FirebaseServices;
using Lab3.FirebaseServices;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidStorage))]
namespace Lab3.Droid.FirebaseServices
{
    public class AndroidStorage : IStorage
    {

        public async Task<string> UploadImage(FileResult image)
        {
            Firebase.Storage.FirebaseStorage storage = Firebase.Storage.FirebaseStorage.Instance;
            var stream = await image.OpenReadAsync();
            var name = System.Guid.NewGuid() + ".jpeg";
            await storage.GetReference(name).PutStream(stream);
            stream.Close();

            var url = await storage.GetReference(name).GetDownloadUrl();
            return url.ToString();
        }

        public async Task<string> UploadVideo(FileResult video)
        {
            Firebase.Storage.FirebaseStorage storage = Firebase.Storage.FirebaseStorage.Instance;
            var stream = await video.OpenReadAsync();
            var name = System.Guid.NewGuid() + ".mp4";
            await storage.GetReference(name).PutStream(stream);
            stream.Close();

            var url = await storage.GetReference(name).GetDownloadUrl();
            return url.ToString();
        }
    }
}