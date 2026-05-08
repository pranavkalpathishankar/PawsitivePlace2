namespace PawsitivePlace.Model.Entities
{
    public static class Credentials
    {
        // For backward compatibility, provide dictionary access to in-memory cache
        private static Dictionary<string, string> _userCache = new();
        private static AppDbContext _dbContext;

        public static Dictionary<string, string> UserCredentials
        {
            get
            {
                // Lazy load from database
                if (_userCache.Count == 0)
                {
                    LoadUsersFromDatabase();
                }
                return _userCache;
            }
        }

        private static void LoadUsersFromDatabase()
        {
            try
            {
                _dbContext ??= new AppDbContext();
                _userCache.Clear();

                var users = _dbContext.Users.ToList();
                foreach (var user in users)
                {
                    _userCache[user.Username] = user.Password;
                }
            }
            catch
            {
                // If database not initialized, keep empty cache
            }
        }

        public static bool AddUser(string username, string password)
        {
            try
            {
                _dbContext ??= new AppDbContext();

                // Check if user already exists
                if (_dbContext.Users.Any(u => u.Username == username))
                    return false;

                // Add new user
                var user = new User { Username = username, Password = password };
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();

                // Update cache
                _userCache[username] = password;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void InitializeDatabase()
        {
            try
            {
                _dbContext ??= new AppDbContext();
                _dbContext.Database.EnsureCreated();
                LoadUsersFromDatabase();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Database initialization error: {ex.Message}");
            }
        }
    }
}
