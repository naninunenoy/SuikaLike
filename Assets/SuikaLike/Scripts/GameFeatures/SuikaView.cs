using TMPro;
using UnityEngine;

namespace SuikaLike.GameFeatures
{
    public class SuikaView : MonoBehaviour, ISuikaViewRenderer
    {
        [SerializeField] TextMeshProUGUI _emoji;
        [SerializeField] TextMeshProUGUI _score;


        public void SetNextEmoji(string emoji)
        {
            _emoji.text = emoji;
        }

        public void SetScore(int score)
        {
            _score.text = score.ToString();
        }
    }
}
