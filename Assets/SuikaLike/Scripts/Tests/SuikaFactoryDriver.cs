using SuikaLike.GameFeatures;
using UnityEngine;

namespace SuikaLike.Tests;

public class SuikaFactoryDriver : ISuikaFactory
{
    public SuikaType GetNextSuika()
    {
        throw new System.NotImplementedException();
    }

    public SuikaObject SpawnSuika(SuikaType type, Vector2 position)
    {
        throw new System.NotImplementedException();
    }
}
