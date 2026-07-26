using FitnessPlatform.DTOs;
using FitnessPlatform.Models;
using FitnessPlatform.Repos;
using FitnessPlatform.Repos.Interfaces;

namespace FitnessPlatform.Services
{
    public class MemberService
    {
        private readonly MemberRepo _memberRepository;

        public MemberService(MemberRepo memberRepository)
        {
            _memberRepository = memberRepository;
        }
        // Get all members
        public async Task<IEnumerable<MemberOutputDTO>> GetAllMembers()
        {
            var members = await _memberRepository.GetAllMembers();

            return members.Select(m => new MemberOutputDTO
            {
                memberId = m.memberId,
                fullName = m.fullName,
                phoneNumber = m.phoneNumber
            });
        }
        // Get member by id
        public async Task<MemberDetailsDTO?> GetMemberById(int id)
        {
            var member = await _memberRepository.GetMemberById(id);

            if (member == null)
                return null;

            return new MemberDetailsDTO
            {
                memberId = member.memberId,
                fullName = member.fullName,
                phoneNumber = member.phoneNumber,
                dateOfBirth = member.dateOfBirth,
                gender = member.gender,
                height = member.height,
                currentWeight = member.currentWeight,
                joinDate = member.joinDate,
                email = member.User.email
            };
        }
        // Create member
        public async Task CreateMember(MemberInputDTO dto,int userId)
        {
            Member member = new Member
            {
                userId = userId,
                fullName = dto.fullName,
                phoneNumber = dto.phoneNumber,
                dateOfBirth = dto.dateOfBirth,
                gender = dto.gender,
                height = dto.height,
                currentWeight = dto.currentWeight,
                joinDate = DateTime.Now
            };

            await _memberRepository.CreateMember(member);
        }
        // Update member
        public async Task<bool> UpdateMember(int id, MemberInputDTO dto)
        {
            var member = await _memberRepository.GetMemberById(id);

            if (member == null)
                return false;

            member.fullName = dto.fullName;
            member.phoneNumber = dto.phoneNumber;
            member.dateOfBirth = dto.dateOfBirth;
            member.gender = dto.gender;
            member.height = dto.height;
            member.currentWeight = dto.currentWeight;

            await _memberRepository.UpdateMember(member);

            return true;
        }
        // Delete member
        public async Task<bool> DeleteMember(int id)
        {
            var member = await _memberRepository.GetMemberById(id);

            if (member == null)
                return false;

            await _memberRepository.DeleteMember(id);

            return true;
        }
    }
}
