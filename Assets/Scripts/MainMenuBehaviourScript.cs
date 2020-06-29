using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// 
/// allows for a button to load a scene
/// 
public class MainMenuBehaviourScript : MonoBehaviour
{
    ///
    /// loads a scene using the scene ID
    ///
    public void LoadScene(int handle)
    {
        SceneManager.LoadScene(handle);
    }

    public void Exit()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }
}