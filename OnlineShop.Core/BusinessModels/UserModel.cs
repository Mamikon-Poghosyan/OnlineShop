namespace OnlineShop.Core.BusinessModels
{
    public class UserModel
    {
        public int SignInId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Wallet { get; set; }
    }
}
                             