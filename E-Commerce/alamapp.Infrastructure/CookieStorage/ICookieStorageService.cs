using System;
namespace alamapp.Infrastructure.CookieStorage
{
   public interface ICookieStorageService
    {
        string Retrieve(string key);
        void Save(string key, string value, DateTime expires);
    }
}
