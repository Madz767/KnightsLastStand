using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LeaderBoard : MonoBehaviour
{

    public TextMeshProUGUI leader;
    public TextAsset textFile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fillLeader();
    }



    public void play()
    {
        SceneManager.LoadScene("Runner");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void quit()
    {
        Application.Quit();
    }


    private void fillLeader()
    {
        string[] data = textFile.text.Split('\n');
        string topPlayers = "";
        for (int i = 0; i < data.Length; i++)
        {
            topPlayers += data[i].Replace(",", " ") + '\n';

        }
        leader.text = topPlayers;
    }






}
