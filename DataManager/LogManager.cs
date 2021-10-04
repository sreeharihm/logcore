using IotLog.Interface;
using IotLog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotLog.DataManager
{
    public class LogManager : IDataRepository<Log>
    {
        readonly LogContext _logContext;
        public LogManager(LogContext context)
        {
            _logContext = context;
        }
        public async Task Add(List<Log> entity)
        {
            _logContext.Logs.AddRange(entity);
            await _logContext.SaveChangesAsync();
        }

        public Task Delete(Log entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Log> Get(long id)
        {
            return  await _logContext.Logs.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<Log>> GetAll()
        {
            return await _logContext.Logs.ToListAsync();
        }

        public Task Update(Log dbEntity, Log entity)
        {
            throw new NotImplementedException();
        }
    }
}
