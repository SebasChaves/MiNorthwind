using DAL.Interfaces;
using Entities;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class ShippersDALImpl : IShippers
    {

        NorthWindContext context;

        #region Contructor
        public ShippersDALImpl()
        {
            context = new NorthWindContext();
        }

        public ShippersDALImpl(NorthWindContext _context)
        {
            context = _context;
        }
        #endregion





        public bool Add(Shipper entity)
            {
                try
                {
                    using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                    {
                        bool flag = unidad.genericDAL.Add(entity);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }

        }

        public void AddRange(IEnumerable<Shipper> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shipper> Find(Expression<Func<Shipper, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Shipper Get(int id)
        {

            using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
            {
                return unidad.genericDAL.Get(id);
            }
        }

        public IEnumerable<Shipper> GetAll()
        {
            using(UnidadDeTrabajo <Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
            {
                return unidad.genericDAL.GetAll();
            }
        }

        public bool Remove(Shipper entity)
        {
            try
            {
                using(UnidadDeTrabajo<Shipper> unidad= new UnidadDeTrabajo<Shipper>(context))
                {
                    return unidad.genericDAL.Remove(entity);
                }
            }catch(Exception ex)
            {
                return false;
            }
        }

        public void RemoveRange(IEnumerable<Shipper> entities)
        {
            throw new NotImplementedException();
        }

        public Shipper SingleOrDefault(Expression<Func<Shipper, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Shipper entity)
        {
            try
            {
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    return unidad.genericDAL.Update(entity);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
