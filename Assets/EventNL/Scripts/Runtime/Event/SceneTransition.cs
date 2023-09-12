using UnityEngine;

namespace NL.Event
{
    public class SceneTransition : MonoBehaviour
    {
        [SerializeField]
        private string _sceneName;
        public void To()
        {
            StartCoroutine(SceneTransitionService.To(_sceneName));
        }
    }
}