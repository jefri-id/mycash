using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Cryptography;
using System.Text;
using MyCash.Models;

namespace MyCash.Controllers
{
    public class RegisterController : ApiController
    {
        private MyCashEntities db = new MyCashEntities();

        [Route("api/register")]
        public HttpResponseMessage PostRegister(UsersViewModel User)
        {
            var arr = User.Name.Split(' ');
            string fn = "", ln = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (i + 1 != arr.Length)
                {
                    fn += arr[i];
                }
                else
                {
                    ln += arr[i];
                }
            }

            int count = (from c in db.Ms_Users where c.Email == User.Email select c).Count();
            if (count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { status = false, message = "The account " + User.Email + " already exists!" });
            }

            else
            {
                if (User.Password != User.ConfirmPass)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { status = false, message = "Confirm password is not match!" });
                }
                else
                {
                    using (MD5 md5Hash = MD5.Create())
                    {
                        string hash = GetMd5Hash(md5Hash, User.Password);
                    }

                    using (var db = new MyCashEntities())
                    {
                        db.Ms_Users.Add(new Ms_Users()
                        {
                            UserID = "DB001",
                            UserType = User.UserType,
                            Email = User.Email,
                            Password = User.Password,
                            CreateDate = DateTime.Now,
                            UpdateDate = null,
                            DeleteDate = null,
                            DeleteBy = null,
                            Dlt = false,
                        });
                        db.SaveChanges();

                        db.Ms_Profiles.Add(new Ms_Profiles()
                        {
                            Name = User.Name,
                            NIK = User.NIK,
                            NIK_Photo = User.NIK_Photo,
                            No_Rekening = User.No_Rekening,
                            Nama_Rekening = User.Nama_Rekening,
                            Bank = User.Bank,
                            Gender = User.Gender,
                            Phone = User.Phone,
                            BirthDate = User.BirthDate,
                            Verified = User.Verified,
                            UpdateTime = DateTime.Now,
                        });
                        db.SaveChanges();
                    }

                    try
                    {
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = true, message = "Registration successful." });
                    }
                    catch (Exception ex)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { status = false, message = "Oops! Something went wrong.", errormessage = ex });
                    }
                }
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
