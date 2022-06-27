using Microsoft.AspNetCore.Identity;

namespace MVCCoreProject.Models
{

    // IdentityErrorDescriber => identiy error hatalarını özelleştirmek için UserRegisterError sınıfını oluşturduk...

    public class UserRegisterError : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = "1",
                Description = $"{email} adresi alınmış. LÜtfen farklı bir email adresi giriniz"
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = "2",
                Description = $"{userName} kullanıcı adı başka bir kullanıcı tarafından alınmış. LÜtfen farklı bir değer giriniz"
            };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError
            {
                Code = "3",
                Description = $"{email} adresi geçersiz. LÜtfen farklı bir email adresi giriniz"
            };
        }
    }
}
