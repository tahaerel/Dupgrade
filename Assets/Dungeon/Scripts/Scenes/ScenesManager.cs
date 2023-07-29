using UnityEngine;
using UnityEngine.SceneManagement;

namespace DungeonKIT
{
    public class ScenesManager : MonoBehaviour
    {
        public static ScenesManager Instance; //Singleton

        [Header("Parameters")]
        public string sceneToLoad; //Set this parameter to the name of the scene you want to go to
        public int levelID; //Current level

        public bool continueGame;

        //Singleton
        void SingletonInit()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Awake()
        {
            SingletonInit(); //Singleton init
        }

        //Load loading scene method
        public void LoadLoadingScene(string sceneToLoad)
        {
            this.sceneToLoad = sceneToLoad; //set sceneToLoad from other managers

            UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScene");
      
        }

        //Method to add a scene to the background
        public void LoadAdditiveScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }

    }
}
