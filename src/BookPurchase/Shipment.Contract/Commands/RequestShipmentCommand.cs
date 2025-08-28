namespace Shipment.Contract.Commands;

public record RequestShipmentCommand(Guid OrderId);