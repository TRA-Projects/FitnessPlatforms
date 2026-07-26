using FitnessPlatform.Models;

namespace FitnessPlatform.Repos.Interfaces
{
    public interface IMemberRepository
    {
        // Get all members
        Task<IEnumerable<Member>> GetAllMembers();

        // Get member by id
        Task<Member?> GetMemberById(int id);

        // Create member
        Task<Member> CreateMember(Member member);

        // Update member
        Task UpdateMember(Member member);

        // Delete member
        Task DeleteMember(int id);
    }
}
