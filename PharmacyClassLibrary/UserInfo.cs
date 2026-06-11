using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;


namespace UserInfoClass
{
    public class UserInfo
    {



        public static string FilePath = "UserInfo.txt";
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Shift { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime lastlogin { get; set; } = DateTime.Now;
        public int password { get; set; }
        public string Status => IsActive ? "Active" : "Inactive";
        public string FullName => Name;
        public bool IsAdmin => Role == "Admin";
        public string RoleBadgeText => Role;
        public string LastLoginDisplay => lastlogin.ToString("yyyy-MM-dd HH:mm");
        public UserInfo(string name, string role, string phone, string shift)
        {
            Name = name;
            Phone = phone;
            Shift = shift;
            IsActive = true;
            Role = role;

        }
        public UserInfo(string name, string role, string phone, string shift, int password)
        {
            Name = name;
            Phone = phone;
            Shift = shift;
            IsActive = true;
            Role = role;
            this.password = password;

        }






        public static void SaveUserInfo(UserInfo user)
        {
            using (FileStream fs = new FileStream(FilePath, FileMode.Append, FileAccess.Write))


            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine($"{user.Name}|{user.Role}|{user.Phone}|{user.Shift}|{user.Status}|{user.password}|{user.lastlogin}");
            }
        }

        //Reading
        public static List<UserInfo> LoadUser()
        {

            List<UserInfo> users = new List<UserInfo>();
            if (!File.Exists(FilePath)) return users;

            using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                string line;
                int id = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 5)
                    {
                        UserInfo user = new UserInfo(parts[0], parts[1], parts[2], parts[3])
                        {
                            Id = id++,
                            Name = parts[0],
                            Role = parts[1],
                            Phone = parts[2],
                            Shift = parts[3],
                            IsActive = true
                        };
                        users.Add(user);
                    }
                }
            }
            return users;
        }
        public static List<UserInfo> LoadUserFull()
        {

            List<UserInfo> users = new List<UserInfo>();
            if (!File.Exists(FilePath)) return users;

            using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                string line;
                int id = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 6)
                    {
                        UserInfo user = new UserInfo(parts[0], parts[1], parts[2], parts[3], int.Parse(parts[5]))
                        {
                            Id = id++,
                            Name = parts[0],
                            Role = parts[1],
                            lastlogin = DateTime.Now,
                            Phone = parts[2],
                            Shift = parts[3],
                            IsActive = true,
                            password = int.Parse(parts[5])




                        };
                        users.Add(user);
                    }
                }
            }
            return users;
        }
        public static List<UserInfo> LoadUserMG()
        {

            List<UserInfo> users = new List<UserInfo>();
            if (!File.Exists(FilePath)) return users;

            using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int id = 1;
                    string[] parts = line.Split('|');
                    if (parts.Length >= 7)
                    {
                        UserInfo user = new UserInfo(parts[0], parts[1], parts[2], parts[3], int.Parse(parts[5]))
                        {
                            Id = id++,
                            Name = parts[0],
                            Role = parts[1],
                            Phone = parts[2],
                            Shift = parts[3],
                            IsActive = parts[4] == "Active",
                            password = int.Parse(parts[5]),
                            lastlogin = DateTime.Parse(parts[6])
                        };
                        users.Add(user);
                    }
                }
            }
            return users;
        }
        public static void DeleteUser(string userName)
        {
            List<UserInfo> users = LoadUser();
            List<UserInfo> updatedUsers = new List<UserInfo>();
            foreach (UserInfo user in users)
            {
                if (user.Name != userName)
                {
                    updatedUsers.Add(user);
                }
            }
            File.WriteAllText(FilePath, "");
            foreach (UserInfo user in updatedUsers)
            {
                SaveUserInfo(user);
            }
        }
        public static UserInfo Login(string name, int password)
        {
            List<UserInfo> users = LoadUserFull();

            foreach (UserInfo user in users)
            {
                if (user.Name == name && user.password == password)
                {
                    user.lastlogin = DateTime.Now;
                    UpdateLastLogin(user);
                    return user;
                }
            }
            return null;
        }

        public static void UpdateLastLogin(UserInfo loggedUser)
        {
            List<UserInfo> allUsers = LoadUserFull();

            File.WriteAllText(FilePath, "");

            foreach (UserInfo user in allUsers)
            {
                if (user.Name == loggedUser.Name)
                {
                    user.lastlogin = loggedUser.lastlogin;
                }
                SaveUserInfo(user);
            }
        }





    }
}



