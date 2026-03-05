using Cysharp.Threading.Tasks;

namespace Infrastructure.Core.UseCases
{
    public interface IUseCase
    {
        UniTask Execute();
    }
}