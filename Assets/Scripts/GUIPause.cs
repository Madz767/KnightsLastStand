using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIPause : MonoBehaviour
{

    public GameObject Pause;

    private void Start()
    {
        Pause.SetActive(false);
    }

    public void playAgain()
    {
        GameManager.instance.resetScene();
        DontDestroyOnLoad(GameManager.instance);
        if (LeaderBoard.instance != null)
        {
            DontDestroyOnLoad(LeaderBoard.instance);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mainMenu()
    {
        GameManager.instance.resetScene();
        GameManager.instance.Player_Score.SetActive(false);
        DontDestroyOnLoad(GameManager.instance);
        GameManager.instance.pauseMenu.SetActive(false);
        Time.timeScale = 1;
        if (LeaderBoard.instance != null)
        {
            DontDestroyOnLoad(LeaderBoard.instance);
            LeaderBoard.instance.gameObject.SetActive(false);
        }
        SceneManager.LoadScene("Menu");

    }

    public void resume()
    {
        GameManager.instance.pause();
    }

    public void leaderBoard()
    {
        GameManager.instance.resetScene();
        GameManager.instance.Player_Score.SetActive(false);
        DontDestroyOnLoad(GameManager.instance);
        if (LeaderBoard.instance != null)
        {
            DontDestroyOnLoad(LeaderBoard.instance);
            LeaderBoard.instance.gameObject.SetActive(true);
        }
        SceneManager.LoadScene("LeaderBoard");
    }

    public void quit()
    {
        Application.Quit();
    }


}
