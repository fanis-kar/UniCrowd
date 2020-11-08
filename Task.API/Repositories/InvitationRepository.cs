using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.API.Data;
using Task.API.Repositories.Interfaces;

namespace Task.API.Repositories
{
    public class InvitationRepository : IInvitationRepository
    {
        private readonly ApplicationDbContext _context;

        public InvitationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Invitation> GetInvitations()
        {
            return _context
                .Invitations
                .ToList();
        }

        public Invitation GetInvitation(int invitationId)
        {
            return _context.Invitations
                .Where(i => i.Id == invitationId)
                .FirstOrDefault();
        }

        public void AddInvitation(Invitation invitation)
        {
            _context.Invitations.Add(invitation);
            _context.SaveChanges();
        }
    }
}
