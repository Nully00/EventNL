using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NL.Event
{
    public static class SceneTransitionService
    {
        public static IEnumerator To(string sceneName)
        {
            yield return To(sceneName, WaitForFrame());

            IEnumerator WaitForFrame()
            {
                yield return null;
            }
        }
        public static IEnumerator To(string sceneName,IEnumerator waitAnimaiton)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                yield return waitAnimaiton;
                if (asyncLoad.progress >= 0.9f)
                {
                    asyncLoad.allowSceneActivation = true;
                    break;
                }
            }
        }
    }
}

