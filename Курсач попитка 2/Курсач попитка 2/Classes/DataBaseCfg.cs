using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Security.Policy;
using System.Security.Permissions;
using MongoDB.Driver.Core.Clusters;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Data;
using Курсач_попитка_2.Classes;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using Guna.UI2.WinForms;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Numerics;

namespace Курсач_попитка_2
{
    public class DataBaseCfg
    {
        private IMongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<User> _collection;
        private IMongoCollection<FamPlace> _collection2;
        public DataBaseCfg()
        {
            _client = new MongoClient(Environment.GetEnvironmentVariable("mongoString"));
            _db = _client.GetDatabase("Users");
            _collection = _db.GetCollection<User>("User");
            _collection2 = _db.GetCollection<FamPlace>("FamPlaces");
        }
        public IMongoCollection<User> GetCollection()
        {
            return _collection;
        }
        public void updateUser(User usr)
        {
            _collection.DeleteOne(u => u.login == usr.login);
            _collection.InsertOne(usr);

        }
        public void AddPlace(FamPlace famPlace)
        {
            _collection2.InsertOne(famPlace);
        }
        public void DeletePlace(string famPlace)
        {
            _collection2.DeleteOne(u => u.Name == famPlace);
        }
        public User GetUser(string login)
        {
            return _collection.Find(u => u.login == login)?.FirstOrDefault();
        }
        public void readFamplaces(DataGridView datagv, User currentUser)
        {
            List<User> users = _collection.Find(u => true).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Країна");
            dt.Columns.Add("Частина Європи");
            dt.Columns.Add("Час візиту");
            dt.Columns.Add("Час роботи");
            dt.Columns.Add("Назва місця");
            dt.Columns.Add("Рейтинг");
            foreach (var famPlace in currentUser.Places)
            {
                dt.Rows.Add(famPlace.location.Country, famPlace.location.EuPart, famPlace.Date, famPlace.Worktime, famPlace.Name, famPlace.Rating);
            }
            datagv.DataSource = dt;
        }
        public void readCollectiveFamplaces(DataGridView datagv)
        {
            List<FamPlace> famPlaces = _collection2.Find(u => true).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Країна");
            dt.Columns.Add("Частина Європи");
            dt.Columns.Add("Час візиту");
            dt.Columns.Add("Час роботи");
            dt.Columns.Add("Назва місця");
            dt.Columns.Add("Рейтинг");
            foreach (var item in famPlaces)
            {
                dt.Rows.Add(item.location.Country, item.location.EuPart, item.Date, item.Worktime, item.Name, item.Rating);
            }
            datagv.DataSource = dt;
        }
        public void ChangeRate(DataGridView datagv, User currentUser, string searchingname, float rating)
        {
            foreach (var famPlace in currentUser.Places)
            {
                if (famPlace.Name == searchingname)
                {
                    famPlace.Rating = rating;
                }
            }
        }
        public void SortByTemp(DataGridView datagv, User currentUser, string temp)
        {
            List<User> users = _collection.Find(u => true).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Країна");
            dt.Columns.Add("Частина Європи");
            dt.Columns.Add("Час візиту");
            dt.Columns.Add("Час роботи");
            dt.Columns.Add("Назва місця");
            dt.Columns.Add("Рейтинг");
            if (temp == "Ім'ям")
            {
                foreach (var famPlace in currentUser.Places.OrderBy(p => p.Name))
                {
                    dt.Rows.Add(famPlace.location.Country, famPlace.location.EuPart, famPlace.Date, famPlace.Worktime, famPlace.Name, famPlace.Rating);
                }
            }
            else if (temp == "Країною")
            {
                foreach (var famPlace in currentUser.Places.OrderBy(p => p.location.Country))
                {
                    dt.Rows.Add(famPlace.location.Country, famPlace.location.EuPart, famPlace.Date, famPlace.Worktime, famPlace.Name, famPlace.Rating);
                }
            }
            else if (temp == "Частиною Європи")
            {
                foreach (var famPlace in currentUser.Places.OrderBy(p => p.location.EuPart))
                {
                    dt.Rows.Add(famPlace.location.Country, famPlace.location.EuPart, famPlace.Date, famPlace.Worktime, famPlace.Name, famPlace.Rating);
                }
            }
            datagv.DataSource = dt;
        }
        public void SearchPlaces(DataGridView datagv, User currentUser, string searchname)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Країна");
            dt.Columns.Add("Робочий час");
            dt.Columns.Add("Дата");
            dt.Columns.Add("Назва");
            dt.Columns.Add("Частина європи");

            foreach (var famPlace in currentUser.Places.Where(p => p.Name.StartsWith(searchname)))
            {
                dt.Rows.Add(famPlace.location.Country, famPlace.Worktime, famPlace.Date, famPlace.Name, famPlace.location.EuPart);
            }
            datagv.DataSource = dt;
        }
    }
}