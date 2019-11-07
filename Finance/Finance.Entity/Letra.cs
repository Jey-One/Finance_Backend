using System;
using System.Collections.Generic;

namespace Finance.Entity
{
    public class Letra
    {
        public int Id {get;set;}
        public string Denominacion {get;set;}
        public string LugarGiro {get;set;}
        public DateTime  FechaGiro {get;set;}
        public string ValorNominal {get;set;}
        public string NombreGirado {get;set;}
        public int DniGirado {get;set;}
        public string NombreBeneficiario {get;set;}
        public string NombreGirador {get;set;}
        public string DniGirador {get;set;}
        public string FirmaGirador {get;set;}
        public DateTime FechaVencimiento {get;set;}
        public string LugarPago {get;set;}
        public int Retencion {get;set;}
        public ICollection<Gasto> Gastos {get;set;}
        public int UserId {get;set;}
        public User User {get;set;}

    }
}