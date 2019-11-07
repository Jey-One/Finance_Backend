using System.Collections.Generic;
using Finance.Entity;
using System;
using Finance.Repository.Context;
using Finance.Repository.DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Finance.Repository.Implementation
{
    public class GastoRepository : IGastoRepository
    {
        private ApplicationDbContext context;
        public GastoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
            try
            {
                Gasto gasto = Get(id);
                context.Gastos.Remove(gasto);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public Gasto Get(int id)
        {
            var result = new Gasto();
            try
            {
                result = context.Gastos.Single(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Gasto> GetAll()
        {
            var result = new List<Gasto>();
            try
            {
                result = context.Gastos
                .Include(gasto => gasto.Letra)    
                .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Gasto> GetAllGastosFinalesByUserId(int letraId)
        {
            var result = new List<Gasto>();
            try
            {
                result = context.Gastos
                .Where(gastos => gastos.Tipo == 2 && gastos.LetraId == letraId)
                .Include(gasto => gasto.Letra)    
                .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Gasto> GetAllGastosInicialesByUserId(int letraId)
        {
            var result = new List<Gasto>();
            try
            {
                result = context.Gastos
                .Where(gastos => gastos.Tipo == 1 && gastos.LetraId == letraId)
                .Include(gasto => gasto.Letra)    
                .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(Gasto entity)
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

        public bool Update(Gasto entity)
        {
            try
            {
                var originalGasto = context.Gastos.Single(
                    gasto => gasto.Id == entity.Id
                );

                originalGasto.Nombre = entity.Nombre;
                originalGasto.Tipo = entity.Tipo;
                originalGasto.Valor = entity.Valor;
                originalGasto.LetraId = entity.LetraId;
               
                context.Update(originalGasto);
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