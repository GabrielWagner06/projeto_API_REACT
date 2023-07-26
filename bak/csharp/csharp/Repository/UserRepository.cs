using csharp.Estities;
using csharp.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace csharp.Repository
{

    public class UserRepository : BaseRepository
    {
        private object users;
        private object row;
        private object st_login;
        private object st_password;

        public string StLogin { get; private set; }
        public List<UserEntity>? GetAll { get; internal set; }




        public void Save(UserEntity entity)
        {
            try
            {
                var passaHash = new Utilities().GenerateHash(entity.St_login, entity.St_password);

                string query = $@"INSERT INTO [USERS2]
                                  VALUES(
                                        '{entity.St_email}',
                                        '{entity.St_role}',
                                        '{entity.St_login}',
                                        '{entity.St_password}',
                                        '{passaHash}
                                        null,
                                        null                                         
)";
                ExecCommand(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(UserEntity entity)
        {
            try
            {
                var passaHash = new Utilities().GenerateHash(entity.St_login, entity.St_password);

                string query = $@"UPDATE [USERS2]
                                    
                                       SET ST_NAME = '{entity.St_name}',
                                        ST_EMAIL = '{entity.St_email}',
                                        ST_ROLE'{entity.St_role}',
                                       ST_LOGIN = '{entity.St_login}',
                                       ST_LOGIN = '{entity.St_password}'
                                        WHERE CD_USUARIO = {entity.Cd_user}";
                ExecCommand(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UserEntity> All
        {
            get
            {
                try
                {
                    String query = $@"Select * FROM [USERS2] WHERE DT_DELETE IS NULL";

                    DataTable result = ExecQuery(query);

                    List<UserEntity> users = new List<UserEntity>();

                    foreach (DataRow row in result.Rows) ;

                    {
                        users.Add(new UserEntity()
                        {
                            Cd_usuario = Convert.ToInt32(result.Rows[0]["CD_USUARIO"]),
                            St_name = Convert.ToString(result.Rows[0]["ST_NAME"]),
                            St_email = Convert.ToString(result.Rows[0]["ST_EMAIL"]),
                            St_role = Convert.ToString(result.Rows[0]["ST_ROLE"]),
                            St_login = Convert.ToString(result.Rows[0]["ST_LOGIN"]),
                            St_password = Convert.ToString(result.Rows[0]["ST_PASSWORD"])
                        });
                    }
                    return users;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Delete(int id, int cd_user) {
            try
            {
                string query = $@"UPDATE [USERS2]
                                SET CD_USER_DELETE = {cd_user},
                                    DT_DELETE = GETDATE()
                                WHERE CD_USUARIO = {id}";
                ExecCommand(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserEntity GetById(int id)
        {
            try
            {
                string query = $@"SELECT * FROM [USERS2] WHERE CD_USUARIO = {id} AND DT_DELETE IS NULL";

                UserEntity user = new();
                DataTable result = ExecQuery(query);
                foreach (DataRow row in result.Rows)
                {
                    user = new UserEntity()
                    {
                        Cd_usuario = Convert.ToInt32(result.Rows[0]["CD_USUARIO"]),
                        St_name = Convert.ToString(result.Rows[0]["ST_NAME"]),
                        St_email = Convert.ToString(result.Rows[0]["ST_EMAIL"]),
                        St_role = Convert.ToString(result.Rows[0]["ST_ROLE"]),
                        St_login = Convert.ToString(result.Rows[0]["ST_LOGIN"]),
                        St_password = Convert.ToString(result.Rows[0]["ST_PASSWORD"])
                    };

                
            }
                return user;
        }
    
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<UserEntity> GetLoog()
        {
            try
            {
                string query = $@"SELECT * FROM [USERS2]";

                UserEntity user = new();
                List<UserEntity> users= new List<UserEntity>();
                DataTable result = ExecQuery(query);
                foreach (DataRow row in result.Rows)
                {
                    user = new UserEntity()
                    {
                        Cd_usuario = Convert.ToInt32(result.Rows[0]["CD_USUARIO"]),
                        St_name = Convert.ToString(result.Rows[0]["ST_NAME"]),
                        St_email = Convert.ToString(result.Rows[0]["ST_EMAIL"]),
                        St_role = Convert.ToString(result.Rows[0]["ST_ROLE"]),
                        St_login = Convert.ToString(result.Rows[0]["ST_LOGIN"]),
                        St_password = Convert.ToString(result.Rows[0]["ST_PASSWORD"])
                    };
                    users.Add(user);
                }
                return users;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
       public UserEntity PostLoog(string st_login, string st_password)
        {
            try
            {
                string query = $@"SELECT * FROM [USERS2] WHERE ST_LOGIN = {st_login} AMD ST_PASSWORD = {st_password}";

                UserEntity user = new UserEntity();
                DataTable result = ExecQuery(query);
                foreach (DataRow row in result.Rows)
                {
                    user = new UserEntity()
                    {
                        St_login = (string)row["ST_LOGIN"],
                        St_password = (string)row["ST_PASSWORD"]
                    };


                }
                return user;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal void delete(UserEntity body)
        {
            throw new NotImplementedException();
        }

        internal void Delete(UserEntity body)
        {
            throw new NotImplementedException();
        }

        

      

        public static implicit operator List<object>(UserRepository v)
        {
            throw new NotImplementedException();
        }
    }
}




