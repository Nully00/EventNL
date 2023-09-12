using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace NL.Event
{
    public class SceneAnimationTransition : MonoBehaviour
    {
        [SerializeField]
        private string _sceneName;
        [SerializeField]
        private Sprite[] _animationSprites;
        [SerializeField]
        private Image _animationImage;
        [SerializeField]
        private float _animationInterval = 0.1f;
        public void To()
        {
            StartCoroutine(SceneTransitionService.To(_sceneName, AnimationImage()));
        }

        private IEnumerator AnimationImage()
        {
            _animationImage.enabled = true;
            foreach (var sprite in _animationSprites)
            {
                _animationImage.sprite = sprite;
                yield return new WaitForSeconds(_animationInterval);
            }
        }
    }
}
