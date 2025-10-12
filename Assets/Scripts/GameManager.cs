using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject pauseMenu;
    //List of Things GameManager will control
    //1: Player Score
    //2: Player is Dead or Not
    //3: collectable abilities





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
        
    }

    public void shieldAbility(Collider2D col)
    {
        if (!Shield)
        {
            PlayerHP -=1;
            Destroy(col.gameObject);
            Debug.Log(PlayerHP);
            return;
        }
        if (Shield)
        {
            score+=1;
            Destroy(col.gameObject);
            Shield = false;
            Debug.Log(score);
            return;
        }

    }

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

    public void isDead()
    {
        //this is my gameOver function
        //it will handle when the player dies
        
        if(getHP() <= 0)
        {
            Time.timeScale = 0;

        }


    }    


}
