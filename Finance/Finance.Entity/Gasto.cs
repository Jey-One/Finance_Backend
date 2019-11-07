using System;

namespace Finance.Entity
{
    public class Gasto
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public int Tipo {get;set;}
        public int Valor {get;set;}
        public int LetraId {get;set;}
        public Letra Letra {get;set;}
    }
}