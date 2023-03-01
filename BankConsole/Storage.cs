using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BankConsole
{
    public static class Storage
    {
        //Declaracion de variables
        static string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\User.json";

        //Metodo
        public static void AddUser(User user)
        {
            //Declaracion de variables
            string json = "", userInFile = "";

            if (File.Exists(filePath))
                userInFile = File.ReadAllText(filePath);

            var listObjects = JsonConvert.DeserializeObject<List<object>>(userInFile);

            if (listObjects == null)
                listObjects = new List<object>();

            listObjects.Add(user);

            JsonSerializerSettings settings = new JsonSerializerSettings { Formatting = Formatting.Indented };

            json = JsonConvert.SerializeObject(listObjects, settings);

            File.WriteAllText(filePath, json);
        }

        public static List<User> GetNewUsers()
        {
            string userInFile = "";
            var listUsers = new List<User>();

            if (File.Exists(filePath))
                userInFile = File.ReadAllText(filePath);

            var listObjects = JsonConvert.DeserializeObject<List<object>>(userInFile);

            if (listObjects == null)
                return listUsers;

            foreach (object obj in listObjects)
            {
                User newUser;
                JObject user = (JObject)obj;

                if (user.ContainsKey("TaxRegime"))
                    newUser = user.ToObject<Client>();
                else
                    newUser = user.ToObject<Employee>();

                listUsers.Add(newUser);
            }

            var newUsersList = listUsers.Where(user => user.GetRegisterDate().Date.Equals(DateTime.Today)).ToList();

            return newUsersList;
        }

        public static string DeleteUser(int ID)
        {
            string json = "", userInFile = "";
            var listUsers = new List<User>();

            if (File.Exists(filePath))
                userInFile = File.ReadAllText(filePath);

            var listObjects = JsonConvert.DeserializeObject<List<object>>(userInFile);

            if (listObjects == null)
                return "No hay usuarios en el Archivo";

             foreach (object obj in listObjects)
            {
                User newUser;
                JObject user = (JObject)obj;

                if (user.ContainsKey("TaxRegime"))
                    newUser = user.ToObject<Client>();
                else
                    newUser = user.ToObject<Employee>();

                listUsers.Add(newUser);
            }

            var userToDelete = listUsers.Where(user => user.GetID() == ID).Single();

            listUsers.Remove(userToDelete);
 
            JsonSerializerSettings settings = new JsonSerializerSettings { Formatting = Formatting.Indented };

            json = JsonConvert.SerializeObject(listUsers, settings);

            File.WriteAllText(filePath, json);

            return "Success";


        }
    }
}