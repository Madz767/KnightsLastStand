using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //List of Things GameManager will control
    //1: Player Score
    //2: Player is Dead or Not




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
        if (getHP() < 3 && Potion)
        {
            PlayerHP++;
            Potion = false;
            Debug.Log(PlayerHP);
        }
    }

    public void shieldAbility(Collider2D col)
    {
        if(Shield)
        {
            score++;
            Destroy(col.gameObject);
            Shield = false;
            Debug.Log(score);
        }
        else if (!Shield)
        {
            PlayerHP--;
            Destroy(col.gameObject);
            Debug.Log(PlayerHP);
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
