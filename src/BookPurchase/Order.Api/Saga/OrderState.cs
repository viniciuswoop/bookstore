using MassTransit;

namespace Order.Api.Saga;

public record OrderState : SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }
    public Guid OrderId { get; set; }
    public string CurrentState { get; set; } = string.Empty;
    public DateTime UpdatedAt { get; set; }
}
