using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Курсач_попитка_2.Classes;
using System.Data;
using System.Windows.Forms;

namespace Курсач_попитка_2.Classes
{
    public class User
    {
        public User(string _login,string _password)
        {
            this.login = _login;
            this.password = _password;
        }
        public User()
        {

        }
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("login")]
        public string login { get; set; }
        [BsonElement("passowrd")]
        public string password { get; set; }
        [BsonElement]
        public List<FamPlace> Places = new List<FamPlace>();
        public void AddPlace(FamPlace place)
        {
            Places.Add(place);
            DataBaseCfg _db = new DataBaseCfg();
            _db.updateUser(this);
        }
        public void DelPlace(string place)
        {
            foreach (var item in Places)
            {
                if (item.Name == place)
                {
                    Places.Remove(item);
                    DataBaseCfg _db = new DataBaseCfg();
                    _db.updateUser(this);
                    return;
                }
            }
        }
    }
        

}
