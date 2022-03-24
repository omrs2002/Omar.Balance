using Volo.Abp.Domain.Services;
using Volo.Abp.Security.Encryption;

namespace Omar.Balance.Services.DomainServices
{
    public class BalanceService : DomainService
    {
        protected IStringEncryptionService StringEncryptionService { get; }

        public BalanceService(IStringEncryptionService stringEncryptionService)
        {
            StringEncryptionService = stringEncryptionService;
        }

        public string Encrypt(string value)
        {
            // To enrcypt a value
            return StringEncryptionService.Encrypt(value);
        }

        public string Decrpyt(string value)
        {
            // To decrypt a value
            return StringEncryptionService.Decrypt(value);
        }
    }

}
