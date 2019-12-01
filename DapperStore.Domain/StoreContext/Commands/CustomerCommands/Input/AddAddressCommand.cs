using System;
using DapperStore.Domain.StoreContext.Entities.Enums;
using DapperStore.Shared.Commands;
using FluentValidator;

namespace DapperStore.Domain.StoreContext.Commands.CustomerCommands.Input
{
    public class AddAddressCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public EAddressType Type { get; set; }

        public bool Valid()
        {
            return IsValid;
        }
    }
}