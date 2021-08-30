using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerListed = "Müşteriler listelendi";
        public static string NotValidated = "Müşteri doğrulanamadı";
        public static string Validated = "Müşteri doğrulandı";
    }
}
