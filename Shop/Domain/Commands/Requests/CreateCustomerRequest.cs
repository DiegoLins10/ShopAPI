﻿namespace Shop.Domain.Commands.Requests
{
    public class CreateCustomerRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
