namespace ReactWithASP.Models
{
    /// <summary>
    /// Represents the login data sent from the client.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// The username entered by the user.
        /// </summary>
        public string Username { get; set; }
        
        /// <summary>
        /// The password entered by the user.
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Indicates whether the user wants to persist the login session.
        /// </summary>
        public bool RememberMe { get; set; }
    }
}
