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


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject pauseMenu;
    public GameObject GameOver;
    public TextMeshProUGUI hpScore;
    public TextMeshProUGUI pointsScore;
    public TextMeshProUGUI nameOfPlayer;
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
        }
        else
        {
            instance = this;
        }
        Time.timeScale = 1;
        updateLeaderBoard();
    }





    //variables
    private int score = 0;
    private int PlayerHP = 3;
    private bool Potion = false;
    private bool Shield = false;
    private bool gamePaused = false;

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
        
        if(getHP() <= 0)
        {
            Time.timeScale = 0;
            GameOver.SetActive(true);
            //updateLeaderBoard();
        }


    }    

    
    private void updateLeaderBoard()
    {


        string[] players = textFile.text.Split('\n');
        
        List<PlayerClass> topPlayers = new List<PlayerClass>();
        PlayerClass goodPlayer;
        for (int i = 0; i < players.Length; i++)
        {

            
            int pos = 0;
            string name = "";
            int score = 0;

            if(i==0)
            {
                string[] data = players[i].Split(',');
                pos = Int32.Parse(data[i]);
                //Debug.Log(pos);
                name = data[i + 1];
                //Debug.Log(name);
                score = Int32.Parse(data[i + 2]);
                //Debug.Log(score);
                //Debug.Log(players[i]);
                goodPlayer = new PlayerClass(pos, name, score);
                topPlayers.Add(goodPlayer);
                i++;
            }

            for (int y = 0; y < 1; y++)
            {
                string[] data = players[i].Split(',');
                pos = Int32.Parse(data[y]);
                //Debug.Log(pos);
                name = data[y + 1];
                //Debug.Log(name);
                score = Int32.Parse(data[y + 2]);
                //Debug.Log(score);


                //Debug.Log(players[i]);
            }


            goodPlayer = new PlayerClass(pos,name, score);
            //Debug.Log(goodPlayer.getPos() + goodPlayer.getName() + goodPlayer.getScore());

            topPlayers.Add(goodPlayer);
        }

        foreach (var item in topPlayers)
        {
            Debug.Log(item.getPos() + item.getName() + item.getScore());
        }





        string playerName = nameOfPlayer.text;
        PlayerClass current = new PlayerClass(0, "testing", 2);
        topPlayers.Add(current);
        topPlayers.OrderBy(x => x.getScore()).ToList();
        topPlayers.Sort();

        int posInList = 0;

        foreach (var item in topPlayers)
        {
            Debug.Log(item.getPos() + item.getName() + item.getScore());
            
            item.setPos(posInList);

            posInList++;
        }



    }



}
