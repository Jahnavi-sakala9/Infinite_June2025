using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Assignment1.Models;
using System.Threading.Tasks;


namespace Assignment1.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(long id);   // may return null; check in controller
        Task CreateAsync(Contact contact);
        Task DeleteAsync(long id);
    }

    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext _ctx;
        public ContactRepository(ContactContext ctx) { _ctx = ctx; }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _ctx.Contacts.AsNoTracking().ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(long id)
        {
            return await _ctx.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateAsync(Contact contact)
        {
            _ctx.Contacts.Add(contact);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _ctx.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            if (entity != null)
            {
                _ctx.Contacts.Remove(entity);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
