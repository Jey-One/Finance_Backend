using System.Collections.Generic;
using Finance.Entity;
using System;
using Finance.Repository.Context;
using Finance.Repository.DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Finance.Repository.Implementation
{
    public class LetraRepository : ILetraRepository
    {
        private ApplicationDbContext context;
        public LetraRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
            try
            {
                Letra letra = Get(id);
                context.Letras.Remove(letra);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public Letra Get(int id)
        {
            var result = new Letra();
            try
            {
                result = context.Letras.Single(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Letra> GetAll()
        {
            var result = new List<Letra>();
            try
            {
                result = context.Letras
                .Include(letras => letras.User)
                .Include(letras => letras.Gastos)    
                .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Letra> GetLetrasByUserId(int userId)
        {
            var result = new List<Letra>();
            try
            {
                result = context.Letras
                .Where(letras => letras.UserId == userId)
                .Include(letras => letras.User)
                .Include(letras => letras.Gastos)    
                .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        /*
        public bool Save(Letra entity)
        {
            try
            { 
                context.Add(entity);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        */
        public bool Save (Letra entity) {

            Letra letra = new Letra {
                Denominacion = entity.Denominacion,
                LugarGiro = entity.LugarGiro,
                FechaGiro = entity.FechaGiro,
                ValorNominal = entity.ValorNominal,
                NombreGirado = entity.NombreGirado,
                DniGirado = entity.DniGirado,
                NombreBeneficiario = entity.NombreBeneficiario,
                NombreGirador = entity.NombreGirador,
                DniGirador = entity.DniGirador,
                FirmaGirador = entity.FirmaGirador,
                FechaVencimiento = entity.FechaVencimiento,
                LugarPago = entity.LugarPago,
                Retencion = entity.Retencion,
                UserId = entity.UserId,
            };
            try {
                context.Letras.Add (letra);
                context.SaveChanges ();
                var letraId = letra.Id;
                foreach (var item in entity.Gastos) {
                    Gasto gasto = new Gasto {
                        Nombre = item.Nombre,
                        Tipo = item.Tipo,
                        Valor = item.Valor,
                        LetraId = letraId
                    };
                    context.Gastos.Add (gasto);
                }
                context.SaveChanges ();
            } catch (Exception ex) {
                return false;
            }
            return true;
        }

        public bool Update(Letra entity)
        {
             try
            {
                var originalLetra = context.Letras.Single(
                    letra => letra.Id == entity.Id
                );

                originalLetra.Denominacion = entity.Denominacion;
                originalLetra.LugarGiro = entity.LugarGiro;
                originalLetra.FechaGiro = entity.FechaGiro;
                originalLetra.ValorNominal = entity.ValorNominal;
                originalLetra.NombreGirado = entity.NombreGirado;
                originalLetra.DniGirado = entity.DniGirado;
                originalLetra.NombreBeneficiario = entity.NombreBeneficiario;
                originalLetra.NombreGirador = entity.NombreGirador;
                originalLetra.DniGirador = entity.DniGirador;
                originalLetra.FirmaGirador = entity.FirmaGirador;
                originalLetra.FechaVencimiento = entity.FechaVencimiento;
                originalLetra.LugarPago = entity.LugarPago;
                originalLetra.Retencion = entity.Retencion;
                originalLetra.UserId = entity.UserId;
                
                /*
                foreach (var item in entity.Gastos) {
                    Gasto gasto = new Gasto {
                        Nombre = item.Nombre,
                        Tipo = item.Tipo,
                        Valor = item.Valor,
                        LetraId = entity.Id
                    };
                    originalLetra.Gastos = gasto;
                }*/

                context.Update(originalLetra);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}