using Core.EventBus;
using Cysharp.Threading.Tasks;

namespace Infrastructure.Core.UseCases
{
    public class PingPongUseCase : IUseCase
    {

        private readonly IEventBus _eventBus;
        
        public PingPongUseCase()
        {
            _eventBus = ServiceLocator.ServiceLocator.Instance.GetService<IEventBus>();
        }
        
        public async UniTask Execute()
        {
            UniTask.Delay(500);
            _eventBus.Publish(new TestEvent());
        }
    }
}