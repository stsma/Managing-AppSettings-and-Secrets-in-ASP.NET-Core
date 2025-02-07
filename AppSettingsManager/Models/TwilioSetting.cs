namespace AppSettingsManager.Models
{
    public class TwilioSetting
    {
        public string? AccountSID { get; set; }
        public string? AuthToken { get; set; }
        public Account Account { get; set; } = new Account();
    }

    public class Account
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
        }
}
