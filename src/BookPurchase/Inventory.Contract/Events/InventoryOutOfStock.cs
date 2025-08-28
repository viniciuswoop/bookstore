namespace Inventory.Contract.Events;

public record InventoryOutOfStock(Guid OrderId);