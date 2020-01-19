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
        public HttpResponseMessage PostRegister(Ms_Users User)
        {
            using (var ctx = new MyCashEntities())
            {
                ctx.Ms_Users.Add(new Ms_Users()
                {
                    UserID = "0000",
                    UserType = User.UserType,
                    Email = User.Email,
                    Password = User.Password,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DeleteDate = DateTime.Now,
                    DeleteBy = "Administrator",
                    Dlt = false
                });
                ctx.SaveChanges();
            }


            return Request.CreateResponse(HttpStatusCode.OK, new { status = true, message = "Berhasil menambah akun baru" });
        }
    }
}
