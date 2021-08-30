using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string OrderAdded = "Sipariş eklendi.";
        public static string OrderUpdated = "Sipariş güncellendi";
        public static string OrderDeleted = "Sipariş silindi";
        public static string OrderListed = "Müşteriler listelendi";
        public static string StatusChanged = "Sipariş durumu değiştirildi";
        
    }
}
