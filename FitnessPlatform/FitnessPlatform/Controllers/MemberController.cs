using FitnessPlatform.DTOs;
using FitnessPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FitnessPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly MemberService _memberService;

        // Constructor
        public MemberController(MemberService memberService)
        {
            _memberService = memberService;
        }

        // GET: api/Member
        // Get all members
        [Authorize(Roles = "Admin,Trainer")]
        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await _memberService.GetAllMembers();
            return Ok(members);
        }

        // GET: api/Member/5
        // Get member by Id
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberById(int id)
        {
            var member = await _memberService.GetMemberById(id);

            if (member == null)
                return NotFound("Member not found.");

            return Ok(member);
        }

        // POST: api/Member
        // Create new member for current logged-in user
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateMember(MemberInputDTO dto)
        {
            // Get userId from JWT token
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value
            );


            await _memberService.CreateMember(dto, userId);


            return Ok("Member created successfully.");
        }

        // PUT: api/Member/5
        // Update member
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, MemberInputDTO dto)
        {
            var result = await _memberService.UpdateMember(id, dto);

            if (!result)
                return NotFound("Member not found.");

            return Ok("Member updated successfully.");
        }

        // DELETE: api/Member/5
        // Delete member
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var result = await _memberService.DeleteMember(id);

            if (!result)
                return NotFound("Member not found.");

            return Ok("Member deleted successfully.");
        }
    }
}