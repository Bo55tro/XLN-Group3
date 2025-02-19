namespace ReactWithASP.Models
{
    /// <summary>
    /// Represents the JWT token returned after a successful login.
    /// </summary>
    public class TokenResponse
    {
        /// <summary>
        /// The generated JWT token.
        /// </summary>
        public string Token { get; set; }
    }
}
