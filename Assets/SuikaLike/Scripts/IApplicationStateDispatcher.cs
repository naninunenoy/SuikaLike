namespace SuikaLike;

public interface IApplicationStateDispatcher
{
    void Dispatch(ApplicationState state);
}
