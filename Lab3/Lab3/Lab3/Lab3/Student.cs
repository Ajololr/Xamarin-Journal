using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Lab3
{
    public class Student
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public DateTime Birthday { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public Position Position => new Position(Latitude ?? 0.0, Longitude ?? 0.0);

        public string[] Images;
        public string Video { get; set; }

        public string Avatar => Images[0];

        public Student()
        {
            Id = "";
            FirstName = "";
            LastName = "";
            SecondName = "";
            Birthday = new DateTime();
            Latitude = 0.0;
            Longitude = 0.0;
            Images = new string[0];
            Video = "";
        }
    }
}
