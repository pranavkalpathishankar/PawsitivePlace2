using System;
using System.Collections.Generic;
using System.Text;

namespace PawsitivePlace.Model.Entities
{
    public static class Credentials
    {
        public static Dictionary<string, string> UserCredentials { get; } = new Dictionary<string, string>
        {
            { "Shetty", "123" },
            { "Man", "456" },
            { "Another", "789" }
        };

        public static bool AddUser(string username, string password)
        {
            if (UserCredentials.ContainsKey(username))
                return false; // User already exists

            UserCredentials.Add(username, password);
            return true; // Successfully added
        }
    }
}
