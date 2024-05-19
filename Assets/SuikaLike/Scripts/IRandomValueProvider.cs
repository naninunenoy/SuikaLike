namespace SuikaLike;

public interface IRandomValueProvider
{
    public int GetRange(int min, int max);
}

public class UnityRandomValueProvider : IRandomValueProvider
{
    public int GetRange(int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }
}
