using System;
using System.IO;
using System.Collections.Generic;

namespace UserInfoClass
{
    public class UserInfo
    {
        public static string FilePath = Path.Combine(AppContext.BaseDirectory, "Userinfo.txt");

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
            Role = role;
            Phone = phone;
            Shift = shift;
            IsActive = true;
        }

        public UserInfo(string name, string role, string phone, string shift, int password)
        {
            Name = name;
            Role = role;
            Phone = phone;
            Shift = shift;
            IsActive = true;
            this.password = password;
        }

        public static void SaveUserInfo(UserInfo user)
        {
            using (FileStream fs = new FileStream(FilePath, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine($"{user.Name}|{user.Role}|{user.Phone}|{user.Shift}|{user.password}|{user.Status}|{user.lastlogin:yyyy-MM-dd HH:mm}");
            }
        }

        public static List<UserInfo> LoadUser()
        {
            List<UserInfo> users = new List<UserInfo>();
            if (!File.Exists(FilePath)) return users;

            string[] lines = File.ReadAllLines(FilePath);
            int id = 1;
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length < 5) continue;

                UserInfo user = new UserInfo(parts[0], parts[1], parts[2], parts[3])
                {
                    Id = id++,
                    IsActive = parts.Length >= 6 && parts[5] == "Active"
                };
                users.Add(user);
            }
            return users;
        }


        public static List<UserInfo> LoadUserFull()
        {
            List<UserInfo> users = new List<UserInfo>();
            if (!File.Exists(FilePath)) return users;

            string[] lines = File.ReadAllLines(FilePath);
            int id = 1;
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length < 6) continue;
                if (!int.TryParse(parts[4], out int password)) continue;

                UserInfo user = new UserInfo(parts[0], parts[1], parts[2], parts[3], password)
                {
                    Id = id++,
                    IsActive = parts[5] == "Active", 
                    password = password
                };
                users.Add(user);
            }
            return users;
        }

        public static List<UserInfo> LoadUserMG()
        {
            List<UserInfo> users = new List<UserInfo>();
            if (!File.Exists(FilePath)) return users;

            string[] lines = File.ReadAllLines(FilePath);
            int id = 1;
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length < 7) continue;
                if (!int.TryParse(parts[4], out int password)) continue;
                if (!DateTime.TryParse(parts[6], out DateTime lastLogin)) continue;

                UserInfo user = new UserInfo(parts[0], parts[1], parts[2], parts[3], password)
                {
                    Id = id++,
                    password = password,
                    IsActive = parts[5] == "Active",
                    lastlogin = lastLogin
                };
                users.Add(user);
            }
            return users;
        }


        public static UserInfo Login(string name, int password)
        {
 
            List<UserInfo> users = LoadUserFull();

            foreach (UserInfo user in users)
            {
                if (user.Name == name && user.password == password && user.IsActive)
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
            List<UserInfo> allUsers = LoadUserMG();
            File.WriteAllText(FilePath, "");

            foreach (UserInfo user in allUsers)
            {
                if (user.Name == loggedUser.Name)
                    user.lastlogin = loggedUser.lastlogin;

                SaveUserInfo(user);
            }
        }
        public static void DeleteUser(string userName)
        {
            List<UserInfo> users = LoadUserMG();
            File.WriteAllText(FilePath, "");

            foreach (UserInfo user in users)
            {
                if (user.Name != userName)
                    SaveUserInfo(user);
            }
        }
    }
}