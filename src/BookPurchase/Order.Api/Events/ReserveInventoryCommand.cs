namespace Order.Api.Events;

public record ReserveInventoryCommand(Guid OrderId, Guid BookId, int quantity);

public record RequestPaymentProcessingCommand(Guid OrderId, string cardnumber, string expireDate, string securityCode);

public record RequestShipmentCommand(Guid OrderId);
