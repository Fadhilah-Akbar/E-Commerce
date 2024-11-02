using ECommerce_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ViewModel;

namespace ECommerce_API.Parent
{
    public class BaseRepository<TEntity, TViewModel, TKey, TContext> : IBaseRepository<TViewModel, TKey>
        where TEntity : class
        where TContext : DB_Market_PlaceContext
    {
        protected readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public async Task<VMResponse<List<TViewModel>>?> GetAllAsync(string? filter = null)
        {
            var query = _context.Set<TEntity>()
                .Where(e => EF.Property<bool>(e, "isDelete") == false)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                // Adjust the column used for filtering according to your requirements
                query = query.Where(e => EF.Functions.Like(e.ToString()!, $"%{filter}%"));
            }

            var data = await query.ToListAsync();

            // Map TEntity to TViewModel if needed
            var viewModelData = data.Select(entity => (TViewModel)Convert.ChangeType(entity, typeof(TViewModel))).ToList();

            return new VMResponse<List<TViewModel>>
            {
                data = viewModelData,
                statusCode = data.Count > 0 ? HttpStatusCode.OK : HttpStatusCode.NoContent,
                message = data.Count > 0 ? "Data found" : "No data available"
            };
        }

        public async Task<VMResponse<TViewModel>?> GetByIdAsync(TKey id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null || EF.Property<bool>(entity, "isDelete"))
            {
                return new VMResponse<TViewModel> { statusCode = HttpStatusCode.NotFound, message = "Data not found or has been deleted" };
            }

            // Map TEntity to TViewModel if needed
            var viewModelData = (TViewModel)Convert.ChangeType(entity, typeof(TViewModel));

            return new VMResponse<TViewModel> { data = viewModelData, statusCode = HttpStatusCode.OK, message = "Data found" };
        }

        public async Task<VMResponse<TViewModel>?> CreateAsync(TViewModel viewModel)
        {
            // Convert TViewModel to TEntity if needed
            var entity = (TEntity)Convert.ChangeType(viewModel, typeof(TEntity))!;

            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return new VMResponse<TViewModel>
            {
                data = viewModel,
                statusCode = HttpStatusCode.Created,
                message = "Data created successfully"
            };
        }

        public async Task<VMResponse<TViewModel>?> UpdateAsync(TViewModel viewModel)
        {
            // Convert TViewModel to TEntity if needed
            var entity = (TEntity)Convert.ChangeType(viewModel, typeof(TEntity))!;

            // Ensure the entity exists in the database
            var existingEntity = await _context.Set<TEntity>().FindAsync(entity.GetType().GetProperty("Id")?.GetValue(entity));
            if (existingEntity == null || EF.Property<bool>(existingEntity, "isDelete"))
            {
                return new VMResponse<TViewModel>
                {
                    statusCode = HttpStatusCode.NotFound,
                    message = "Data not found or has been deleted"
                };
            }

            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();

            return new VMResponse<TViewModel>
            {
                data = viewModel,
                statusCode = HttpStatusCode.OK,
                message = "Data updated successfully"
            };
        }

        public async Task<VMResponse<TViewModel>?> DeleteAsync(TKey key, int deletedBy)
        {
            var entity = await _context.Set<TEntity>().FindAsync(key);
            if (entity == null || EF.Property<bool>(entity, "isDelete"))
            {
                return new VMResponse<TViewModel> { statusCode = HttpStatusCode.NotFound, message = "Data not found or already deleted" };
            }

            // Set soft delete properties
            _context.Entry(entity).Property("isDelete").CurrentValue = true;
            _context.Entry(entity).Property("deleteBy").CurrentValue = deletedBy;
            _context.Entry(entity).Property("deleteOn").CurrentValue = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Map back to TViewModel if needed
            var viewModelData = (TViewModel)Convert.ChangeType(entity, typeof(TViewModel));

            return new VMResponse<TViewModel>
            {
                data = viewModelData,
                statusCode = HttpStatusCode.OK,
                message = "Data deleted successfully"
            };
        }
    }
}
