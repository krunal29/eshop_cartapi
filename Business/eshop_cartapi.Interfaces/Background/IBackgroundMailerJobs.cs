namespace eshop_cartapi.Interfaces.Background
{
    public interface IBackgroundMailerJobs : IBackgroundJobs
    {
        void SendWelcomeEmail();

        void ForgotPassword(string emailId, string passwordReset);
    }
}