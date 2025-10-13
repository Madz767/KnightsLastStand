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
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void resume()
    {
        GameManager.instance.pause();
    }

    public void leaderBoard()
    {
        SceneManager.LoadScene("LeaderBoard");
    }

    public void quit()
    {
        Application.Quit();
    }


}
