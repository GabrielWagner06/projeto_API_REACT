using System.Data;
using System.Security.Claims;

namespace csharp.Estities
{
    public class UserEntity : BaseEntity
    {
        public string St_name { get; set; }
        public int Cd_usuario { get; set; }
        public string St_email { get; set; }
        public string St_login { get; set; }
        public string St_password { get; set; }
        public string St_role { get; set; }
        public string? St_profile { get; set; }
        public string? Nr_standardCost { get; internal set; }
        public string? St_number { get; internal set; }

        public static implicit operator DataTable(UserEntity v)
        {
            throw new NotImplementedException();
        }

        //public static implicit operator List<object>(UserEntity v)


    }
    }


