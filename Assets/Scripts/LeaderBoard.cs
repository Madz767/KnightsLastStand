using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    public static LeaderBoard instance;
    public TextMeshProUGUI leader;
    public TextAsset textFile;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            
        }
        else
        {
            instance = this;
        }

        //if(!firstRead)
        //{
        //    fillLeaderFromText();
        //    Debug.Log("I am awake -Leader1" + firstRead);
        //}
        //else if (firstRead)
        //{
        //    fillLeaderFromText();
        //    Debug.Log("I am awake -Leader2" + firstRead);
        //}
        
        //updateLeaderBoard();
    }


    private void OnEnable()
    {
        fillLeaderFromText();
    }

    public void mainMenu()
    {
        DontDestroyOnLoad(GameManager.instance);
        if (LeaderBoard.instance != null)
        {
            DontDestroyOnLoad (LeaderBoard.instance);
            LeaderBoard.instance.gameObject.SetActive(false);
        }
        SceneManager.LoadScene("Menu");
    }

    public void quit()
    {
        Application.Quit();
    }


    public void fillLeaderFromText()
    {
        string[] data = textFile.text.Split('\n');
        string topPlayers = "";
        for (int i = 0; i < data.Length; i++)
        {
            topPlayers += data[i].Replace(",", " ") + '\n';

        }
        leader.text = topPlayers;
    }

    //private void fillLeaderFromList()
    //{

    //    string name = "";
    //    leader.text = "";
    //    int score = 0;
    //    for (int i = 0; i < 5; i++)
    //    {
    //        name = GameManager.instance.topPlayers[i].getName();
    //        score = GameManager.instance.topPlayers[i].getScore();
    //        leader.text += name + score.ToString() + "\n";
    //    }
    //    //leader.text = name + score.ToString() + "\n";
    //}




}
