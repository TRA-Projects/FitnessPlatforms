using FitnessPlatform.Models;
using FitnessPlatform.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlatform.Repos
{
    public class SubscriptionRepo: ISubscriptionRepository
    {
        private readonly FitnessContext _context;//its a variable thet represent DB


        public SubscriptionRepo(FitnessContext context)
        {
            _context = context;//Constructor that make ASP.NET give us copy of DB automatically
        }


        // Get all subscriptions
        public async Task<IEnumerable<Subscription>> GetAllSubscriptions()
        {
            return await _context.Subscriptions
                .Include(s => s.Member)
                .Include(s => s.MembershipPlan)
                .ToListAsync();
        }


        // Get subscription by id
        public async Task<Subscription?> GetSubscriptionById(int id)
        {
            return await _context.Subscriptions
                .Include(s => s.Member)
                .Include(s => s.MembershipPlan)
                .FirstOrDefaultAsync(s => s.subscriptionId == id);
        }
        // Create subscription
        public async Task<Subscription> CreateSubscription(
            Subscription subscription)
        {
            _context.Subscriptions.Add(subscription);//add repo to subscription table

            await _context.SaveChangesAsync();//save it at SQL Server

            return subscription;
        }


        // Update subscription
        public async Task UpdateSubscription(
            Subscription subscription)
        {
            _context.Subscriptions.Update(subscription);

            await _context.SaveChangesAsync();
        }


        // Delete subscription
        public async Task DeleteSubscription(int id)
        {
            var subscription = await GetSubscriptionById(id);//search for a repo

            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);//delete it

                await _context.SaveChangesAsync();//save the deletion
            }
        }
﻿using FitnessPlatform.Repos.Interfaces;

namespace FitnessPlatform.Repos
{
    public class SubscriptionRepo : ISubscriptionRepository
    {

    }

}
