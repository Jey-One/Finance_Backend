using  System;
using System.Collections.Generic;
namespace Finance.Entity
{
    public class User
    {
        public int Id {get;set;}
        public string Username {get;set;}
        public string Password {get;set;}
        public string Name {get;set;}
        public string UrlImage {get;set;}
        public ICollection<Letra> Letras;

    }
}