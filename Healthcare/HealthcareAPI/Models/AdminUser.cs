namespace HealthcareAPI.Models
{
    public class AdminUser
    {
        public int AdminUserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}