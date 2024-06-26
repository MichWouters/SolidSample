﻿using System;
using ArdalisRating.Logging;
using ArdalisRating.Policies;


namespace ArdalisRating.Raters
{
    public class LifePolicyRating : IPolicyRater
    {
        private ILogger logger;
        private RatingEngine engine;

        public LifePolicyRating(RatingEngine engine, ILogger logger)
        {
            this.engine = engine;
            this.logger = logger;
        }

        public void Rate(Policy policy)
        {
            logger.WriteMessage("Rating LIFE policy...");
            logger.WriteMessage("Validating policy.");
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                logger.WriteMessage("Life policy must include Date of Birth.");
                return;
            }
            
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                logger.WriteMessage("Centenarians are not eligible for coverage.");
                return;
            }
            
            if (policy.Amount == 0)
            {
                logger.WriteMessage("Life policy must include an Amount.");
                return;
            }
            int age = DateTime.Today.Year - policy.DateOfBirth.Year;
            
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < policy.DateOfBirth.Day ||
                DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = policy.Amount * age / 200;
            
            if (policy.IsSmoker)
            {
                engine.Rating = baseRate * 2;
            }
            engine.Rating = baseRate;
        }
    }
}
