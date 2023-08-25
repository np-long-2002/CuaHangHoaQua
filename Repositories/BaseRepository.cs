using CuaHangHoaQua.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace CuaHangHoaQua.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected readonly DataContext _dataContext;
        protected BaseRepository()
        {
            _dataContext = new DataContext();
        }
        public IQueryable<T> GetAll()
        {
            try
            {
                return _dataContext.Set<T>();
            }catch (Exception ex)
            {
                throw new Exception($"Error getting entity: {ex.Message}", ex);
            }
        }
        public async Task<T?> GetId(int id)
        {
            try
            {
                var allid = await _dataContext.Set<T>().FindAsync(id);
                return allid;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting entity: {ex.Message}", ex);
            }
        }
        public async Task Create(T cr)
        {
            try
            {
                await _dataContext.Set<T>().AddAsync(cr);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting entity: {ex.Message}", ex);
            }
        }
        public async Task Edit(T ed)
        {
            try
            {
                _dataContext.Set<T>().Update(ed);
                await _dataContext.SaveChangesAsync();
            }catch (Exception ex)
            {
                throw new Exception($"Error getting entity: {ex.Message}", ex);
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                var allid = await _dataContext.Set<T>().FindAsync(id);
                if(allid != null)
                {
                    _dataContext.Set<T>().Remove(allid);
                    await _dataContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting entity: {ex.Message}", ex);
            }
        }
    }
}
