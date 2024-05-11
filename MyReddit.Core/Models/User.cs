namespace MyReddit.Core.Models
{
    public class User
    {
        public const int max_userName_length = 20;
        public const int min_password_length = 8;
        private User(Guid id, string userName, string password, string email)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Email = email;
            Posts = [];
        }
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public List<Post> Posts { get; }
        public static (User User, string Error) Create(Guid id, string userName, string password, string email)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(userName) || userName.Length > max_userName_length)
            {
                error += string.Format("UserName can`t be empty or must be leaser than {0} symbols\n", max_userName_length);
            }

            if (string.IsNullOrEmpty(password) || password.Length < min_password_length)
            {
                error += string.Format("Password can`t be empty or must be greater than {0} symbols\n", min_password_length);
            }

            if (string.IsNullOrEmpty(email) || !email.Contains('@'))
            {
                error += "Email can`t be empty or must contains domain (example: max@mail.ru)";
            }

            var user = new User(id, userName, password, email);
            return (user, error);
        }
        public void CreatePost(Post post)
        {
            ArgumentNullException.ThrowIfNull(post, nameof(post));

            Posts.Add(post);
        }
    }
}
