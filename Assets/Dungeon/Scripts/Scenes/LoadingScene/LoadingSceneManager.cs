using UnityEngine;
using UnityEngine.SceneManagement;

namespace DungeonKIT
{
    public class LoadingSceneManager : MonoBehaviour
    {
        private void Start()
        {
            LoadScene(); //Call load scene method whe LoadingScene is loaded
        }

        //Loading scene method
        void LoadScene()
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene(ScenesManager.Instance.sceneToLoad);

            //Call static SceneManager to load scene
        }
    }
}