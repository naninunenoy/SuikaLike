using NUnit.Framework;
using SuikaLike.GameFeatures;
using UnityEngine;
using VContainer;

namespace SuikaLike.Tests;

//https://yotiky.hatenablog.com/entry/unity_testframework4-vcontainer
[TestFixture]
public class SuikaScorePresenterTest
{
    [Inject] SuikaScorePresenter _target;
    [Inject] IObjectResolver _container;

    SuikaViewRendererMock _rendererMock;

    [SetUp]
    public void Setup()
    {
        _rendererMock = new SuikaViewRendererMock();
        var builder = new ContainerBuilder();

        builder.RegisterInstance<ISuikaViewRenderer>(_rendererMock);
        builder.Register<SuikaScorePresenter>(Lifetime.Transient);
        _container = builder.Build();
        _container.Inject(this);
    }

    [Test]
    public void 得点が反映されるかのテスト()
    {
        var objectA = new SuikaObject
        {
            Id = new SuikaId(0), Type = SuikaType.Tiny, GameObject = new GameObject("A")
        };
        var objectB = new SuikaObject
        {
            Id = new SuikaId(1), Type = SuikaType.Tiny, GameObject = new GameObject("B")
        };

        var command = new SameTypeSuikaCollisionCommand
        {
            OriginalType = SuikaType.Tiny, Originals = new[] { objectA, objectB },
        };

        _target.__DontCallMe(command);

        // tiny + tiny = normalで3点
        Assert.That(_rendererMock.LastSetScore, Is.EqualTo(3));
    }

}

internal class SuikaViewRendererMock : ISuikaViewRenderer
{
    public string LastSetEmoji { get; private set; } = string.Empty;
    public int LastSetScore { get; private set; }
    public void SetNextEmoji(string emoji) => LastSetEmoji = emoji;
    public void SetScore(int score) => LastSetScore = score;
}
