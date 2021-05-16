using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Lab3.FirebaseServices
{
    public interface IStorage
    {
        Task<string> UploadVideo(FileResult video);

        Task<string> UploadImage(FileResult image);
    }
}
