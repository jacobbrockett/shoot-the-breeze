using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    /**
    * function: StartGame()
    * args: None
    * description: Linked to a button that will start the game (i.e., load the gameplay scene)
    */
    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Options()
    {
        Debug.Log("Options");
        // TODO: add options menu
    }

    /**
    * function: QuitGame()
    * args: None
    * description: Linked to a button that will quit the game
    */
    public void QuitGame(){
        Application.Quit(); // nothing will happen in Unity Editor! only works when you build the game
    }
}
