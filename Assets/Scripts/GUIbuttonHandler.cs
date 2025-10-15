using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIbuttonHandler : MonoBehaviour
{
    public GameObject Menu_Canvas;
    public TMP_InputField playerName;
    public GameObject GameOver;
    public GameObject Pause_Menu;
    public GameObject Player_HP;

    private static bool firstRun = true;

    public void Start()
    {
        if (!firstRun)
        {
            GameManager.instance.resetScene();
        }
        Player_HP.SetActive(false);
        firstRun = false;
    }

    public void loadPlay()
    {

        GameManager.instance.setPlayerName(playerName.text);

        DontDestroyOnLoad(GameManager.instance);

        if (LeaderBoard.instance != null)
        {
            DontDestroyOnLoad(LeaderBoard.instance);
           
        }

        DontDestroyOnLoad(GameOver);
        DontDestroyOnLoad(Pause_Menu);
        DontDestroyOnLoad(Player_HP);
        GameManager.instance.Player_Score.SetActive(true);
        GameManager.instance.enabled = true;
        SceneManager.LoadScene("Runner");
    }

    public void loadLB()
    {
        
        DontDestroyOnLoad (GameManager.instance);
        if (LeaderBoard.instance != null)
        {
            DontDestroyOnLoad(LeaderBoard.instance);
            LeaderBoard.instance.gameObject.SetActive(true);
        }

        DontDestroyOnLoad(GameOver);
        DontDestroyOnLoad(Pause_Menu);
        DontDestroyOnLoad(Player_HP);
        SceneManager.LoadScene("LeaderBoard");
    }

    public void exitGame()
    {
        //will only work on the full build
        Application.Quit();
    }




}
