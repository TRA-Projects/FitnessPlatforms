using FitnessPlatform.DTOs;
using FitnessPlatform.Models;
using FitnessPlatform.Repos;
using FitnessPlatform.Repos.Interfaces;

namespace FitnessPlatform.Services
{
    public class UserService
    {
     private readonly IUserRepository _userRepository;
        private readonly AuthService _authService;
        private readonly EmailService _emailService;

        // Constructor
        public UserService(
        IUserRepository userRepository,AuthService authService, EmailService emailService) 
        {
            _userRepository = userRepository;
            _authService = authService;
            _emailService = emailService;
        }

        // Get all users
        public async Task<IEnumerable<UserOutputDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();

            return users.Select(u => new UserOutputDTO  //يحول Model إلى DTO
            {
                userId = u.userId,
                userName = u.userName,
                email = u.email,
                Role = u.Role
            });
        }
        // Get user by id
        public async Task<UserDetailsDTO?> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
                return null;

            return new UserDetailsDTO
            {
                userId = user.userId,
                userName = user.userName,
                email = user.email,
                Role = user.Role,
                isActive = user.isActive,
                createdAt = user.createdAt
            };
        }
        // Register new user
        public async Task<bool> Register(RegisterDTO dto)
        {
            // تحقق إن الإيميل مو مسجل من قبل
            var existingUser = await _userRepository.GetUserByEmail(dto.email);

            if (existingUser != null)
                return false; // الإيميل مستخدم من قبل

            User user = new User
            {
                userName = dto.username,
                email = dto.email,

                // تشفير الباسورد قبل الحفظ - لا يترخزن أبداً كنص عادي
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),

                // Role دايماً ثابتة "Member" بالتسجيل العام
                // لا تؤخذ من dto.Role إطلاقاً (منع أي مستخدم يسجل نفسه Admin)
                Role = "Member",

                createdAt = DateTime.UtcNow,
                isActive = true
            };

            await _userRepository.CreateUser(user);

            Member member = new Member
            {
               fullName = dto.username,
               currentWeight = dto.currentWeight
            
            
            
            };
         
            //send email
            await _emailService.SendEmailAsync(
                user.email,
                "Welcome to Fitness Platform",
                $"Hello {user.userName}, Welcome to Fitness Platform!"
            );

            return true;
        }

        // Login user and generate JWT Token
        public async Task<LoginResponseDTO?> Login(LoginDTO dto)
        {
            // Find user by email
            var user =
                await _userRepository.GetUserByEmail(dto.email);


            if (user == null)
                return null;



            // Check password
            bool passwordValid =
                BCrypt.Net.BCrypt.Verify(
                    dto.Password,
                    user.PasswordHash
                );


            if (!passwordValid)
                return null;



            // Generate token
            var token =
                _authService.GenerateToken(
                    user.userId,
                    user.userName,
                    user.Role
                );



            return new LoginResponseDTO
            {
                Token = token,

                userName = user.userName,

                Role = user.Role
            };
        }




        // Update user
        public async Task<bool> UpdateUser(int id, UpdateUserDTO dto)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
                return false;

            user.userName = dto.userName;
            user.email = dto.email;

            await _userRepository.UpdateUser(user);

            return true;
        }

        // Delete user
        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
                return false;

            await _userRepository.DeleteUser(id);

            return true;
        }

    }
}
