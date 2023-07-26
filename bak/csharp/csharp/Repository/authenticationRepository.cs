using csharp.Estities;
using csharp.Utils;
using System.Data;

namespace csharp.Repository
{
    public class authenticationRepository : BaseRepository
    {
        private object result;

        public UserEntity login(string login, string password)
        {
            try
            {
                var hashPass = new Utilities().GenerateHash(login, password);
                string query = $@"SELECT * FROM [USERS2]
                              WHERE ST_LOGIN = '{login}'
                              AND ST_PASSWOSD = '{password}'
                              AND DT_DELETE IS NULL";


                UserEntity user = new UserEntity();
                DataTable result = ExecQuery(query);

                if (result.Rows.Count == 0)
                    return null;

                user = new UserEntity()
                {
                    Cd_usuario = Convert.ToInt32(result.Rows[0]["CD_USUARIO"]),
                    St_name = Convert.ToString(result.Rows[0]["ST_NAME"]),
                    St_email = Convert.ToString(result.Rows[0]["ST_EMAIL"]),
                    St_role = Convert.ToString(result.Rows[0]["ST_ROLE"]),
                    St_login = Convert.ToString(result.Rows[0]["ST_LOGIN"]),
                    St_password = Convert.ToString(result.Rows[0]["ST_PASSWORD"])
                };
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal object login(UserEntity body)
        {
            throw new NotImplementedException();
        }
    }
}
