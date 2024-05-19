namespace SuikaLike.GameFeatures;

public enum SuikaType
{
    Smallest,
    Tiny,
    Normal,
    Large,
    Huge,
    Gigantic,
    Biggest,
}

public static class SuikaTypeExtensions
{
    public static float GetSize(this SuikaType type)
    {
        return type switch
        {
            SuikaType.Smallest => 0.6f,
            SuikaType.Tiny => 0.8f,
            SuikaType.Normal => 1.0f,
            SuikaType.Large => 1.5f,
            SuikaType.Huge => 2.0f,
            SuikaType.Gigantic => 3.0f,
            SuikaType.Biggest => 4.0f,
            _ => 1.0f,
        };
    }

    public static string GetEmoji(this SuikaType type)
    {
        return type switch
        {
            SuikaType.Smallest => "🥺",
            SuikaType.Tiny => "🤔",
            SuikaType.Normal => "😆",
            SuikaType.Large => "😠",
            SuikaType.Huge => "😋",
            SuikaType.Gigantic => "🤪",
            SuikaType.Biggest => "🤓",
            _ => "😀",
        };
    }

    public static bool TryGetNextEvolution(this SuikaType type, out SuikaType nextType)
    {
        nextType = type switch
        {
            SuikaType.Smallest => SuikaType.Tiny,
            SuikaType.Tiny => SuikaType.Normal,
            SuikaType.Normal => SuikaType.Large,
            SuikaType.Large => SuikaType.Huge,
            SuikaType.Huge => SuikaType.Gigantic,
            SuikaType.Gigantic => SuikaType.Biggest,
            //SuikaType.Biggest => SuikaType.Smallest,
            _ => SuikaType.Normal,
        };
        // Biggestの次はない
        return type != SuikaType.Biggest;
    }
}
