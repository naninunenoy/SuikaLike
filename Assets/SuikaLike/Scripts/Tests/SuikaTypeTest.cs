using NUnit.Framework;
using SuikaLike.GameFeatures;

namespace SuikaLike.Tests
{
    public class SuikaTypeTest
    {
        [Test]
        public void GetSizeTest()
        {
            Assert.AreEqual(0.6f, SuikaLike.GameFeatures.SuikaType.Smallest.GetSize());
            Assert.AreEqual(0.8f, SuikaLike.GameFeatures.SuikaType.Tiny.GetSize());
            Assert.AreEqual(1.0f, SuikaLike.GameFeatures.SuikaType.Normal.GetSize());
            Assert.AreEqual(1.5f, SuikaLike.GameFeatures.SuikaType.Large.GetSize());
            Assert.AreEqual(2.0f, SuikaLike.GameFeatures.SuikaType.Huge.GetSize());
            Assert.AreEqual(3.0f, SuikaLike.GameFeatures.SuikaType.Gigantic.GetSize());
            Assert.AreEqual(4.0f, SuikaLike.GameFeatures.SuikaType.Biggest.GetSize());
        }

        [Test]
        public void GetEmojiTest()
        {
            Assert.AreEqual("🥺", SuikaLike.GameFeatures.SuikaType.Smallest.GetEmoji());
            Assert.AreEqual("🤔", SuikaLike.GameFeatures.SuikaType.Tiny.GetEmoji());
            Assert.AreEqual("😆", SuikaLike.GameFeatures.SuikaType.Normal.GetEmoji());
            Assert.AreEqual("😠", SuikaLike.GameFeatures.SuikaType.Large.GetEmoji());
            Assert.AreEqual("😋", SuikaLike.GameFeatures.SuikaType.Huge.GetEmoji());
            Assert.AreEqual("🤪", SuikaLike.GameFeatures.SuikaType.Gigantic.GetEmoji());
            Assert.AreEqual("🤓", SuikaLike.GameFeatures.SuikaType.Biggest.GetEmoji());
        }

        [Test]
        public void GetScoreTest()
        {
            Assert.AreEqual(0, SuikaLike.GameFeatures.SuikaType.Smallest.GetScore());
            Assert.AreEqual(1, SuikaLike.GameFeatures.SuikaType.Tiny.GetScore());
            Assert.AreEqual(3, SuikaLike.GameFeatures.SuikaType.Normal.GetScore());
            Assert.AreEqual(5, SuikaLike.GameFeatures.SuikaType.Large.GetScore());
            Assert.AreEqual(10, SuikaLike.GameFeatures.SuikaType.Huge.GetScore());
            Assert.AreEqual(20, SuikaLike.GameFeatures.SuikaType.Gigantic.GetScore());
            Assert.AreEqual(50, SuikaLike.GameFeatures.SuikaType.Biggest.GetScore());
        }
    }
}
