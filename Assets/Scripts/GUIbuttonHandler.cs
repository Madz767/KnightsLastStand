using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIbuttonHandler : MonoBehaviour
{
    public GameObject Menu_Canvas;


    public void loadPlay()
    {
        SceneManager.LoadScene("Runner");
    }

    public void loadLB()
    {
        SceneManager.LoadScene("LeaderBoard");
    }

    public void exitGame()
    {
        //will only work on the full build
        Application.Quit();
    }

    public void resumeGame()
    {

    }



}
