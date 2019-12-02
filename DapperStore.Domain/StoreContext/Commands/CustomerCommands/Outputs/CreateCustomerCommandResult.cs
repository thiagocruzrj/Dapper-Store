using System;
using DapperStore.Shared.Commands;

namespace DapperStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get ; set ; }
        public string Message { get ; set ; }
        public object Data { get ; set ; }
    }
}