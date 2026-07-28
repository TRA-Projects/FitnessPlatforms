
﻿using FitnessPlatform.DTOs;
﻿using FitnessPlatform.Models;
using FitnessPlatform.Repos;
using FitnessPlatform.Repos.Interfaces;
using static FitnessPlatform.DTOs.SubscriptionDTOs;

namespace FitnessPlatform.Services
{
    public class SubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        // Get all subscriptions
        public async Task<IEnumerable<SubscriptionOutputDTO>> GetAllSubscriptions()
        {
            var subscriptions = await _subscriptionRepository.GetAllSubscriptions();

            return subscriptions.Select(s => new SubscriptionOutputDTO
            {
                subscriptionId = s.subscriptionId,
                fullName = s.Member.fullName,
                planName = s.MembershipPlan.planName,
                IsActive = s.IsActive
            });
        }


        // Get subscription by id
        public async Task<SubscriptionDetailsDTO?> GetSubscriptionById(int id)
        {
            var subscription = await _subscriptionRepository.GetSubscriptionById(id);

            if (subscription == null)
                return null;

            return new SubscriptionDetailsDTO
            {
                subscriptionId = subscription.subscriptionId,
                fullName = subscription.Member.fullName,
                planName = subscription.MembershipPlan.planName,
                price = subscription.MembershipPlan.price,
                durationInDays = subscription.MembershipPlan.durationInDays,
                startDate = subscription.startDate,
                EndDate = subscription.EndDate,
                IsActive = subscription.IsActive
            };
        }

        // Create subscription
        public async Task CreateSubscription(SubscriptionInputDTO dto)
        {
            Subscription subscription = new Subscription
            {
                memberId = dto.memberId,
                planId = dto.planId
            };

            await _subscriptionRepository.CreateSubscription(subscription);
        }


        // Update subscription
        public async Task<bool> UpdateSubscription(int id, SubscriptionInputDTO dto)
        {
            var subscription = await _subscriptionRepository.GetSubscriptionById(id);

            if (subscription == null)
                return false;

            subscription.memberId = dto.memberId;
            subscription.planId = dto.planId;

            await _subscriptionRepository.UpdateSubscription(subscription);

            return true;
        }


        // Delete subscription
        public async Task<bool> DeleteSubscription(int id)
        {
            var subscription = await _subscriptionRepository.GetSubscriptionById(id);

            if (subscription == null)
                return false;

            await _subscriptionRepository.DeleteSubscription(id);

            return true;
        }
    }

}
