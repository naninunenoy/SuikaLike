using TMPro;
using UnityEngine;

namespace SuikaLike
{
    public class SuikaComponent : MonoBehaviour
    {
        [SerializeField] TextMeshPro _text = default;
        [SerializeField] CapsuleCollider2D _collider = default;

        public TextMeshPro Text => _text;
        public CapsuleCollider2D Collider => _collider;
    }
}
