using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.BusinessLayer.Interfaces;
using WebApi.BusinessLayer.Models;
using WebApi.DataAccessLayer;

namespace WebApi.BusinessLayer.Classes
{
    public class GroupService : IGroupService
    {
        private readonly GroupManagementDbContext _context;
        public GroupService(GroupManagementDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Group>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                var groups = await _context.Groups.AsNoTracking().OrderBy(entity => entity.Id).ToListAsync(cancellationToken);

                return groups.Select(x => new Group { Id = x.Id, Name = x.Name });
                //return Mapper.Map<List<Group>>(groups);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Group> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var group = await _context.Groups.AsNoTracking().SingleOrDefaultAsync(entity => entity.Id == id, cancellationToken);
                return Mapper.Map<Group>(group);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Group> UpdateAsync(Group group, CancellationToken ct)
        {
            try
            {
                var updatedGroupEntry = _context.Groups.Update(group.ToEntity());
                await _context.SaveChangesAsync(ct);
                return Mapper.Map<Group>(updatedGroupEntry.Entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Group> AddAsync(Group group, CancellationToken ct)
        {
            try
            {
                var addedGroupEntry = _context.Groups.Add(group.ToEntity());
                await _context.SaveChangesAsync(ct);
                return Mapper.Map<Group>(addedGroupEntry.Entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Group> RemoveAsync(Group group, CancellationToken ct)
        {
            try
            {
                var removedGroupEntry = _context.Groups.Remove(group.ToEntity());
                await _context.SaveChangesAsync(ct);
                return Mapper.Map<Group>(removedGroupEntry.Entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
