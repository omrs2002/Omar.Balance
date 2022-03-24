using System.Text;
using Volo.Abp.Application.Services;
using Volo.Abp.Security.Encryption;

namespace Omar.Balance.Services.AppServices
{
    public class BalanceService : ApplicationService
    {

        protected IStringEncryptionService _stringEncryptionService { get; }

        public BalanceService(IStringEncryptionService stringEncryptionService)
        {
            _stringEncryptionService = stringEncryptionService;
        }
        public string Encrypt(string s)
        {
            var encrypted = _stringEncryptionService.Encrypt(s);
            var valueBytes = Encoding.UTF8.GetBytes(encrypted);
            var encodedQueryString = Convert.ToBase64String(valueBytes);
            return encodedQueryString;

        }

        public string Decrypt(string base64string)
        {
            byte[] strbytes =  Convert.FromBase64String(base64string);
            string str = Encoding.Default.GetString(strbytes);
            var decrtpted =  _stringEncryptionService.Decrypt(str);
            return decrtpted;
        }



    }
}
