using MSSQL;
using DBIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using PagedList;
using PagedList.Mvc;

namespace Code_Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["login"] == null)
                return RedirectToAction("SignIn", "Home");
            else
            {
                DAO db = new DAO();
                List<Product> list = db.GetObject_Product(1, 12 );
                return View(list);
            }    
        }

        /// Đọc thêm Activity
        [HttpPost]
        public ActionResult GetMoreProduct(FormCollection collection)
        {
            int Page = int.Parse(collection["page"]);
            DAO db = new DAO();
            List<Product> list = db.GetObject_Product(Page, 12);
            return View(list);
        }


        #region AddAccount

        [HttpGet]
        public ActionResult CreareAccount()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult AddAccount(FormCollection collection)
        {
            JsonResult jr = new JsonResult();
            string username = collection["username"];
            string email = collection["email"];
            string pwd = collection["pwd"];
            if (!String.IsNullOrEmpty(username) &&
                !String.IsNullOrEmpty(email) &&
                !String.IsNullOrEmpty(pwd))
            {
                using (DAO db = new DAO())
                {
                    Account ac = db.GetObject_AccountByEmail(email);
                    if (ac != null)
                    {
                        jr.Data = new
                        {
                            status = "ER",
                            message = "Email [" + email + "] đã được sử dụng. Hãy sử dụng email khác!"
                        };
                    }
                    else
                    {
                        // ACCOUNT
                        ac = new Account();
                        ac.UniqueID = Guid.NewGuid().ToString();
                        ac.Email = email;
                        ac.UserName = username;
                        ac.Password = GetHash(pwd, HashType.MD5);
                        db.AddObject(ac);
                        jr.Data = new
                        {
                            status = "OK"
                        };
                        
                    }
                }
            }
            else
            {
                jr.Data = new
                {
                    status = "ER",
                    message = "Thiếu dữ liệu [UserName]  hoặc [EMAIL]  hoặc [Password] "
                };
            }
            return Json(jr, JsonRequestBehavior.AllowGet);
        }
        #endregion AddAccount

        #region SignIn
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Check(FormCollection collection)
        {
            // INPUT
            string username = collection["username"];
            string pwd = collection["pwd"];
            // CHECK
            JsonResult jr = new JsonResult();
            using (DAO db = new DAO())
            {
                Account acu = db.GetObject_AccountsByEmail(username, GetHash(pwd, HashType.MD5));
                Account ace = db.GetObject_AccountsByUserName(username, GetHash(pwd, HashType.MD5));
                if (acu == null)
                {
                    if(ace == null)
                    {
                        jr.Data = new
                        {
                            status = "FA",
                            message = "Đăng nhập thất bại."
                        };
                    }
                    else
                    {
                        Session["login"] = ace;
                        Session.Timeout = 60 * 24;

                        jr.Data = new
                        {
                            status = "OK",
                            message = "Đăng nhập thành công."
                        };
                    }
                }
                else
                {
                    Session["login"] = acu;
                    Session.Timeout = 60 * 24;

                    jr.Data = new
                    {
                        status = "OK",
                        message = "Đăng nhập thành công."
                    };
                    
                }
            }
            return Json(jr, JsonRequestBehavior.AllowGet);
        }


        #endregion SignIn

        #region SignOut

        public JsonResult Logout()
        {
            Session.Clear();
            JsonResult jr = new JsonResult();
            jr.Data = "OK";
            return Json(jr, JsonRequestBehavior.AllowGet);
        }
        #endregion SignOut

        #region Product
        public ActionResult Product()
        {
            DAO db = new DAO();
            List<Product> list = db.GetObject_Product(1, 12);
            return View(list);
        }


        #endregion Product

        #region HASH
        public enum HashType : int
        {
            MD5,
            SHA1,
            SHA256,
            SHA512
        }

        public static string GetHash(string text, HashType hashType)
        {
            string hashString;
            switch (hashType)
            {
                case HashType.MD5:
                    hashString = GetMD5(text);
                    break;
                case HashType.SHA1:
                    hashString = GetSHA1(text);
                    break;
                case HashType.SHA256:
                    hashString = GetSHA256(text);
                    break;
                case HashType.SHA512:
                    hashString = GetSHA512(text);
                    break;
                default:
                    hashString = "Invalid Hash Type";
                    break;
            }
            return hashString;
        }

        public static bool CheckHash(string original, string hashString, HashType hashType)
        {
            string originalHash = GetHash(original, hashType);
            return (originalHash == hashString);
        }

        private static string GetMD5(string text)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            byte[] message = UE.GetBytes(text);

            MD5 hashString = new MD5CryptoServiceProvider();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }

        private static string GetSHA1(string text)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            byte[] message = UE.GetBytes(text);

            SHA1Managed hashString = new SHA1Managed();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }

        private static string GetSHA256(string text)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            byte[] message = UE.GetBytes(text);

            SHA256Managed hashString = new SHA256Managed();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }

        private static string GetSHA512(string text)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            byte[] message = UE.GetBytes(text);

            SHA512Managed hashString = new SHA512Managed();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
        #endregion HASH

    }
}