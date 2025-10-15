using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem.Controls;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using Unity.VisualScripting;
using System.IO;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject pauseMenu;
    public GameObject GameOver;
    public GameObject Player_Score;
    public TextMeshProUGUI hpScore;
    public TextMeshProUGUI pointsScore;
    public TextAsset textFile;
    //List of Things GameManager will control
    //1: Player Score
    //2: Player is Dead or Not
    //3: collectable abilities
    //4: menus





    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            Player_Score.SetActive(true);
        }
        else
        {
            instance = this;
        }
        Time.timeScale = 1;
        //updateLeaderBoard();
    }





    //variables
    private int score = 0;
    private int PlayerHP = 3;
    private bool gameDead = false;
    private bool Potion = false;
    private bool Shield = false;
    private static bool gamePaused = false;
    private string pName = string.Empty;
    public List<PlayerClass> topPlayers = new List<PlayerClass>();


    public int getScore()
    {
        return score;
    }
    public void setScore(int s)
    {
        score = s;
    }
    public int getHP()
    {
        return PlayerHP;
    }
    public void setHP(int hp)
    {
        PlayerHP = hp;
    }

    //this is for the potion collectable
    public void setPotion(bool active)
    {
        Potion = active;
    }
    public bool getPotion()
    {
        if (Potion)
        {
            return true;
        }
        return false;
    }

    //this is for the shield collectable
    public void setShield(bool active)
    {
        Shield = active;
    }

    public bool getShield()
    {
        if (Shield)
        {
            return true;
        }
        return false;
    }


    //this is for the player name
    public string getPlayerName()
    {
        if(pName == string.Empty)
        {
            return "Unkown";
        }
        return pName;
    }
    
    public void setPlayerName(string s)
    {
        pName = s;
    }
    

    //collecable abilities
    public void potionAbility()
    {
        PlayerHP++;
        Potion = false;
        Debug.Log(PlayerHP);
        updateStats();
        
    }

    public void shieldAbility(Collider2D col)
    {
        if (!Shield)
        {
            PlayerHP -=1;
            Destroy(col.gameObject);
            Debug.Log(PlayerHP);
            updateStats();
            return;
        }
        if (Shield)
        {
            score+=1;
            Destroy(col.gameObject);
            Shield = false;
            Debug.Log(score);
            updateStats();
            return;
        }

    }

    //canvas functions
    public void pause()
    {
        if (!gamePaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            gamePaused = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            gamePaused = false;
        }

    }

    public void updateStats()
    {
        string hp = "HP: " + getHP().ToString();
        string points = "Points: " + getScore().ToString();
        //hpScore.GetComponent<Text>().text += hp;
        hpScore.text = hp;
        pointsScore.text = points;
        

    }



    public void isDead()
    {
        //this is my gameOver function
        //it will handle when the player dies
        
        if(getHP() <= 0 && !gameDead)
        {
            Time.timeScale = 0;
            pName = getPlayerName();
            updateLeaderBoard(pName);
            GameOver.SetActive(true);
            gameDead = true;
        }


    }    

    public void resetScene()
    {
        setHP(3);
        setScore(0);
        GameOver.SetActive(false);
        gameDead=false;
        Time.timeScale = 1;
    }


    public void updateLeaderBoard(string pName)
    {
        //Debug.Log("just in update leaderboard");

        string[] players = textFile.text.Split('\n');
        topPlayers.Clear();
        Debug.Log("just read the textfile");

        PlayerClass goodPlayer;
        for (int i = 0; i < players.Length-1; i++)
        {

            

            string name = "";
            int score = 0;

            if(i==0)
            {
                string[] data = players[i].Split(',');
                name = data[i];
                //Debug.Log(name);
                score = Int32.Parse(data[i + 1]);
                //Debug.Log(score);
                //Debug.Log(players[i]);
                goodPlayer = new PlayerClass(name, score);
                topPlayers.Add(goodPlayer);
                i++;
            }

            for (int y = 0; y < 1; y++)
            {
                string[] data = players[i].Split(',');


                name = data[y];
                //Debug.Log(name);
                score = Int32.Parse(data[y + 1]);
                //Debug.Log(score);
                

                //Debug.Log(players[i]);
                goodPlayer = new PlayerClass(name, score);
                topPlayers.Add(goodPlayer);
            }
            


            //Debug.Log(goodPlayer.getName() + goodPlayer.getScore());
            //Debug.Log("about to add player to list" + topPlayers[i]);
            
;
        }

        //Debug.Log("right after creating a list");
        //foreach (var item in topPlayers)
        //{
        //    Debug.Log(item.getName() + item.getScore() + "after creating the first list");

        //}



        PlayerClass current = new PlayerClass(getPlayerName(), getScore());
        topPlayers.Add(current);

        Debug.Log("just added current to list");

        //this will sort the list in a descending order based on score
        //or if you want to know how it works code wise it sorts it
        //based on the second item in the class which in this case is score
        topPlayers.Sort((a, b) => b.getScore().CompareTo(a.getScore()));
        //Debug.Log("this is right after sorting");

        //removing the 6th position then testing to see if it worked
        topPlayers.RemoveAt(topPlayers.Count - 1);
        foreach (var item in topPlayers)
        {
            Debug.Log(item.getName() + item.getScore());

        }



        //writing to the text file
        string filePath = Application.dataPath + "/HighScores.txt";
        StreamWriter writing = new StreamWriter(filePath);
        foreach (var item in topPlayers)
        {
            writing.WriteLine(item.getName() + "," + item.getScore());

        }
        writing.Close();
    }



}
