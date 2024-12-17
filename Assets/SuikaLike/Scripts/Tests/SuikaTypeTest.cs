using NUnit.Framework;
using SuikaLike.GameFeatures;

namespace SuikaLike.Tests;

public class SuikaTypeTest
{
    [Test]
    public void GetSizeTest()
    {
        Assert.AreEqual(0.6f, SuikaType.Smallest.GetSize());
        Assert.AreEqual(0.8f, SuikaType.Tiny.GetSize());
        Assert.AreEqual(1.0f, SuikaType.Normal.GetSize());
        Assert.AreEqual(1.5f, SuikaType.Large.GetSize());
        Assert.AreEqual(2.0f, SuikaType.Huge.GetSize());
        Assert.AreEqual(3.0f, SuikaType.Gigantic.GetSize());
        Assert.AreEqual(4.0f, SuikaType.Biggest.GetSize());
    }

    [Test]
    public void GetEmojiTest()
    {
        Assert.AreEqual("🥺", SuikaType.Smallest.GetEmoji());
        Assert.AreEqual("🤔", SuikaType.Tiny.GetEmoji());
        Assert.AreEqual("😆", SuikaType.Normal.GetEmoji());
        Assert.AreEqual("😠", SuikaType.Large.GetEmoji());
        Assert.AreEqual("😋", SuikaType.Huge.GetEmoji());
        Assert.AreEqual("🤪", SuikaType.Gigantic.GetEmoji());
        Assert.AreEqual("🤓", SuikaType.Biggest.GetEmoji());
    }

    [Test]
    public void GetScoreTest()
    {
        Assert.AreEqual(0, SuikaType.Smallest.GetScore());
        Assert.AreEqual(1, SuikaType.Tiny.GetScore());
        Assert.AreEqual(3, SuikaType.Normal.GetScore());
        Assert.AreEqual(5, SuikaType.Large.GetScore());
        Assert.AreEqual(10, SuikaType.Huge.GetScore());
        Assert.AreEqual(20, SuikaType.Gigantic.GetScore());
        Assert.AreEqual(50, SuikaType.Biggest.GetScore());
    }
}
