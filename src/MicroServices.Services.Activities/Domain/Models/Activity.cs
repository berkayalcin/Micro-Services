﻿using System;
using MicroServices.Common.Exceptions;

namespace MicroServices.Services.Activities.Domain.Models
{
    public class Activity
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public string Category { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreatedAt { get; protected  set; }

        protected Activity()
        {
        }

        public Activity(Guid id,string category,Guid userId,string name,string description,DateTime createdAt)
        {

            if (String.IsNullOrWhiteSpace(name))
            {
                throw new MicroServicesException("empty_activity_name", $"Activity name can not be empty.");
            }
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Category = category;
            UserId = userId;
            CreatedAt = createdAt;

        }
    }
}