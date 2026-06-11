using System;
using System.IO;
using System.Collections.Generic;

namespace UserInfoClass
{
	public class UserInfo
	{


		private string username;
		private string password;
		private string role;
		public DateTime lastlogin { set; get; }


		public string Role
		{
			get { return role; }
			set { role = value; }
		}
		public string Username
		{
			get { return username; }
			set { username = value; }
		}
		public string Password
		{
			get { return password; }
			set { password = value; }
		}
		public UserInfo(string username, string password, string role)
		{
			this.username = username;
			this.password = password;
			this.role = role;
			lastlogin = DateTime.Now;
		}
		public static void SaveUserInfo(UserInfo user)
		{
			using (FileStream fs = new FileStream("UserInfo.txt", FileMode.Append, FileAccess.Write))


			using (StreamWriter sw = new StreamWriter(fs))
			{
				sw.WriteLine($"{user.Username}|{user.Password}|{user.Role}|{user.lastlogin}");
			}
		}

		//Reading
		public static List<UserInfo> LoadUser()
		{
			List<UserInfo> users = new List<UserInfo>();
			using (FileStream fs = new FileStream("UserInfo.txt", FileMode.OpenOrCreate, FileAccess.Read))
			{
				using (StreamReader sr = new StreamReader(fs)) ;
				{
					string line;
					while ((line = sr.ReadLine()) != null)
					{
						string[] parts = line.Split('|');
						if (parts.Length == 4)
						{
							string username = parts[0];
							string password = parts[1];
							string role = parts[2];
							DateTime lastlogin;
							if (DateTime.TryParse(parts[3], out lastlogin))
							{
								UserInfo user = new UserInfo(username, password, role);
								user.lastlogin = lastlogin;
								users.Add(user);
							}
						}
					}
				}
				return users;
			}




		}
	}
}

