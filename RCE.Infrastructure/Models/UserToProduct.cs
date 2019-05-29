﻿using RCE.Commons.Abstracts;
using System;

namespace RCE.Infrastructure.Entities
{
    public class UserToProduct : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Amount { get; set; }
        public int Day { get; set; }
        public string PaymentDetail { get; set; }
        public byte Point { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}