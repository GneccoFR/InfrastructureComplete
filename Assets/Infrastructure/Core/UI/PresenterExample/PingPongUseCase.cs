using Core.EventBus;
using Cysharp.Threading.Tasks;
using Infrastructure.Core.UseCases;

namespace Infrastructure.Core.UI.PresenterExample
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