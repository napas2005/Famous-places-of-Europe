using Guna.UI2.WinForms;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач_попитка_2
{
    public class FamPlace
    {
        public FamPlace(string _country, string _eupart,DateTime _date, string _worktime, string _name, float _rating, PictureBox _pic)
        {
            location = new Location(_country, _eupart);
            Date = _date;
            Worktime = _worktime;
            Name = _name;   
            Rating = _rating;
            Pic = _pic;
        }
            [BsonId]
            public ObjectId Id { get; set; }
            [BsonElement]
            public DateTime Date;
            [BsonElement]
            public string Worktime;
            [BsonElement]
            public string Name;
            [BsonElement]
            public Location location;
            [BsonElement]
            public float Rating;
            [BsonIgnore]
            public PictureBox Pic { get; set; }

    }
    public class Location
    {
        [BsonElement]
        public string Country;
        [BsonElement]
        public string EuPart;


        public Location(string country, string eupart)
        {
            Country = country;
            EuPart = eupart;    
        }

    }
}
