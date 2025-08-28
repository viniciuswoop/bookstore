namespace Payment.Contract.Events;

public record PaymentProcessed(Guid OrderId);