using Core.Infrastructure;
using Infrastructure.Core.UI.ViewExample;
using Infrastructure.Core.UseCases;

namespace Infrastructure.Core.UI.PresenterExample
{
    public class PingPongTestPresenter : BasePresenter
    {
        private PingPongTestView _view;
    
        public PingPongTestPresenter(IView view) : base(view)
        {
            _view = view as PingPongTestView;
        }
    

        public override void Initialize()
        {
            SubscribeEvents();
            _view.TogglePongText(false);
        }

        public override void SubscribeEvents()
        {
            EventBus.Subscribe<TestEvent>(PingEvent);
        }

        public override void UnSubscribeEvents()
        {
            EventBus.Unsubscribe<TestEvent>(PingEvent);
        }

        private void PingEvent(TestEvent obj)
        {
            _view.TogglePongText(true);
            _view.SetPongText("PONG!");
        }

        public void PingButtonPressed()
        {
            var pingPongUseCase = new PingPongUseCase();
            pingPongUseCase.Execute();
        }

        public override void Dispose()
        {
            UnSubscribeEvents();
        }
    }
}
