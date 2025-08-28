namespace Payment.Contract.Commands;

public record RequestPaymentProcessingCommand(Guid OrderId, string cardnumber, string expireDate, string securityCode);