using MassTransit;
using Order.Api.Events;

namespace Order.Api.Saga;

public class OrderStateMachine : MassTransitStateMachine<OrderState>
{
    public State Created { get; private set; }
    public State ProcessingInventory { get; private set; }
    public State ProcessingPayment { get; private set; }
    public State ProcessingShipment { get; private set; }
    public State OrderCancelled { get; private set; }
    public State Completed { get; private set; }

    public Event<OrderSubmitted> OrderSubmitted { get; private set; }
    public Event<InventoryReserved> InventoryReserved { get; private set; }
    public Event<PaymentProcessed> PaymentProcessed { get; private set; }
    public Event<ShipmentCreated> ShipmentCreated { get; private set; }
    public Event<InventoryOutOfStock> InventoryOutOfStock { get; private set; }
    public Event<PaymentRejected> PaymentRejected { get; private set; }
    public Event<DeveliryNotAvailable> DeveliryNotAvailable { get; private set; }
    public Event<Shipped> Shipped { get; private set; }

    public OrderStateMachine()
    {
        InstanceState(x => x.CurrentState);

        Event(() => OrderSubmitted, x => x.CorrelateById(m => m.Message.OrderId));
        Event(() => InventoryReserved, x => x.CorrelateById(m => m.Message.OrderId));
        Event(() => PaymentProcessed, x => x.CorrelateById(m => m.Message.OrderId));
        Event(() => ShipmentCreated, x => x.CorrelateById(m => m.Message.OrderId));
        Event(() => InventoryOutOfStock, x => x.CorrelateById(m => m.Message.OrderId));
        Event(() => PaymentRejected, x => x.CorrelateById(m => m.Message.OrderId));
        Event(() => DeveliryNotAvailable, x => x.CorrelateById(m => m.Message.OrderId));
        Event(() => Shipped, x => x.CorrelateById(m => m.Message.OrderId));

        Initially(
            When(OrderSubmitted)
                .TransitionTo(ProcessingInventory)
                    .Publish(context => new ReserveInventoryCommand(context.Message.OrderId, Guid.NewGuid(), 10))
        );

        During(ProcessingInventory,
            When(InventoryReserved)
                .TransitionTo(ProcessingPayment)
                    .Publish(context => new RequestPaymentProcessingCommand(context.Message.OrderId, "", "", ""))
        );

        During(ProcessingPayment,
            When(PaymentProcessed)
                .TransitionTo(ProcessingShipment)
                    .Publish(context => new RequestShipmentCommand(context.Message.OrderId)),
            When(PaymentRejected)
                .TransitionTo(OrderCancelled)
        );

        During(ProcessingShipment,
            When(Shipped)
                .TransitionTo(Completed),
            
            When(DeveliryNotAvailable)
                .TransitionTo(OrderCancelled)
        );

    }
}
