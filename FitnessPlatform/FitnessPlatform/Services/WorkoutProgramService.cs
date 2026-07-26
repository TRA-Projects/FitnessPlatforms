using FitnessPlatform.DTOs;
using FitnessPlatform.Models;
using FitnessPlatform.Repos;
using FitnessPlatform.Repos.Interfaces;

namespace FitnessPlatform.Services
{
    public class WorkoutProgramService
    {
        private readonly IWorkoutProgramRepository _workoutProgramRepository;

        public WorkoutProgramService(IWorkoutProgramRepository workoutProgramRepository)
        {
            _workoutProgramRepository = workoutProgramRepository;
        }

        // Get all workout programs
        public async Task<IEnumerable<WorkoutProgramOutputDTO>> GetAllWorkoutPrograms()
        {
            var programs = await _workoutProgramRepository.GetAllWorkoutPrograms();

            return programs.Select(p => new WorkoutProgramOutputDTO
            {
                programId = p.programId,
                programName = p.programName,
                memberName = p.Member.fullName,
                trainerName = p.Trainer.fullName,
                DurationInWeeks = p.DurationInWeeks,
                Goal = p.Goal
            });
        }

        // Get workout program by id
        public async Task<WorkoutProgramDetailsDTO?> GetWorkoutProgramById(int id)
        {
            var program = await _workoutProgramRepository.GetWorkoutProgramById(id);

            if (program == null)
                return null;

            return new WorkoutProgramDetailsDTO
            {
                programId = program.programId,
                programName = program.programName,
                createdAt = program.createdAt,
                DurationInWeeks = program.DurationInWeeks,
                Goal = program.Goal,
                memberName = program.Member.fullName,
                trainerName = program.Trainer.fullName
            };
        }

        // Create workout program
        public async Task CreateWorkoutProgram(WorkoutProgramInputDTO dto)
        {
            WorkoutProgram program = new WorkoutProgram
            {
                programName = dto.programName,
                DurationInWeeks = dto.DurationInWeeks,
                Goal = dto.Goal,
                memberId = dto.memberId,
                trainerId = dto.trainerId
            };

            await _workoutProgramRepository.CreateWorkoutProgram(program);
        }

        // Update workout program
        public async Task<bool> UpdateWorkoutProgram(int id, WorkoutProgramInputDTO dto)
        {
            var program = await _workoutProgramRepository.GetWorkoutProgramById(id);

            if (program == null)
                return false;

            program.programName = dto.programName;
            program.DurationInWeeks = dto.DurationInWeeks;
            program.Goal = dto.Goal;
            program.memberId = dto.memberId;
            program.trainerId = dto.trainerId;

            await _workoutProgramRepository.UpdateWorkoutProgram(program);

            return true;
        }

        // Delete workout program
        public async Task<bool> DeleteWorkoutProgram(int id)
        {
            var program = await _workoutProgramRepository.GetWorkoutProgramById(id);

            if (program == null)
                return false;

            await _workoutProgramRepository.DeleteWorkoutProgram(id);

            return true;
        }
    }
}
