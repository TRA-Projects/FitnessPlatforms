using FitnessPlatform.Models;
using FitnessPlatform.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlatform.Repos
{
    public class MemberRepo : IMemberRepository
    {
        private readonly FitnessContext _context;

      public MemberRepo(FitnessContext context)
        {
            _context= context;
        }

        // Get all members
        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            return await _context.Members
                .Include(m => m.User)
                .ToListAsync();
        }
        // Get member details by id
        public async Task<Member?> GetMemberById(int id)
        {
            return await _context.Members
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.memberId == id);
        }

        // Create member
        public async Task<Member> CreateMember(Member member)
        {
            _context.Members.Add(member);

            await _context.SaveChangesAsync();

            return member;
        }
        // Update member
        public async Task UpdateMember(Member member)
        {
            _context.Members.Update(member);

            await _context.SaveChangesAsync();
        }
        // Delete member
        public async Task DeleteMember(int id)
        {
            var member = await GetMemberById(id);

            if (member != null)
            {
                _context.Members.Remove(member);

                await _context.SaveChangesAsync();
            }
        }

    }
}
