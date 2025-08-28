namespace Inventory.Contract.Commands;

public record ReserveInventoryCommand(Guid OrderId, Guid BookId, int quantity);
