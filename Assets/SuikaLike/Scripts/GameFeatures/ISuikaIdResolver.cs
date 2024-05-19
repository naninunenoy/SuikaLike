namespace SuikaLike.GameFeatures;

public interface ISuikaIdResolver
{
    bool TryGetById(SuikaId id, out SuikaObject suika);
}
