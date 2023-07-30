using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playbutton : MonoBehaviour
{
    public void buttonclickplay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
