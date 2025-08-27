namespace Order.Api.Events;

public record OrderSubmitted(Guid OrderId);

public record InventoryReserved(Guid OrderId);

public record PaymentProcessed(Guid OrderId);

public record ShipmentCreated(Guid OrderId);

public record InventoryOutOfStock(Guid OrderId);

public record PaymentRejected(Guid OrderId);

public record DeveliryNotAvailable(Guid OrderId);

public record Shipped(Guid OrderId);
