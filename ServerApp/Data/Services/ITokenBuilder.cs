namespace ServerApp.Data.Services
{
    public interface ITokenBuilder
    {
        ITokenBuilder AddAudience   ();
        ITokenBuilder AddClaims     ();
        ITokenBuilder AddExpiry     ();
        ITokenBuilder AddIssuer     ();
        ITokenBuilder AddSecurityKey();

        string Build();
    }
}