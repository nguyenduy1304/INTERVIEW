using MSSQL;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DBIO
{
    public class DAO : IDisposable
    {
        public Connection dbContext = new Connection();

        public DAO()
        {
            dbContext.Database.CommandTimeout = 1800;
        }

        #region Implement IDisposable 

        private IntPtr nativeResource = Marshal.AllocHGlobal(100);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~DAO()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            if (nativeResource != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeResource);
                nativeResource = IntPtr.Zero;
            }
        }

        #endregion

        #region ADD

        /// ADD chung chung
        public void AddObject<T>(T obj)
        {
            dbContext.Set(obj.GetType()).Add(obj);
            dbContext.SaveChanges();
        }
        #endregion

        #region READ

        #region Account

        /// Đọc 1 object CRM_Accounts theo Email
        public Account GetObject_AccountByEmail(string Email)
        {
            return dbContext.Accounts.Where(c => c.Email == Email).FirstOrDefault();
        }
        /// Đọc 1 object CRM_Accounts theo Email && Pass
        public Account GetObject_AccountsByUserName(string UserName, string Pass)
        {
            return dbContext.Accounts.Where(c => c.UserName == UserName && c.Password == Pass).FirstOrDefault();
        }
        /// Đọc 1 object CRM_Accounts theo Email && Pass
        public Account GetObject_AccountsByEmail(string Email, string Pass)
        {
            return dbContext.Accounts.Where(c => c.Email == Email && c.Password == Pass).FirstOrDefault();
        }
        #endregion END Account


        #region Product

        /// Đọc 1 object Product theo ID
        public Product GetObject_ProductById(int id)
        {
            return dbContext.Products.Where(c => c.UniqueID == id).FirstOrDefault();
        }

        /// <summary>
        /// Đọc danh sách object CRM_ActivityList theo AccountID & PAGE
        /// </summary>
        public List<Product> GetObject_Product(int Page, int ItemPerPage)
        {
            var obj = dbContext.Products;
            int Max = obj.Any() ? obj.Max(c => c.UniqueID) : 1;

            int From = Max - (ItemPerPage * (Page - 1)) - (ItemPerPage - 1);
            if (From < 1) From = 1;
            int To = From + (ItemPerPage - 1);
            return obj.Where(c => c.UniqueID >= From && c.UniqueID <= To).OrderByDescending(c => c.UniqueID).ToList();
        }
        #endregion Product


        #endregion END READ
    }
}