using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //to be able to work with scenes

public class MainMenuController : MonoBehaviour
{
    public void NextLevel()
    {
        //SceneManager.LoadScene("MainMenu"); //argument can be the name of the scene
        //SceneManager.LoadScene(0); //argument can be the build index
        
        //this will always go to the next in the build index whetever scene you're currently on
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        //Pre-processor directives will help us quit game once it is built or when we are still editing
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //this will quit the game when we are editing
#else
        Application.Quit(); //This will quit the game but only once it is built
#endif
    }
}
