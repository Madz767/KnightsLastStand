using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private GameObject Shield_Player;
    private GameObject Potion_Player;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Potion_Player = GameObject.FindGameObjectWithTag("Equipped_Potion");
        Shield_Player = GameObject.FindGameObjectWithTag("Equipped_Shield");
        Potion_Player.SetActive(false);
        Shield_Player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.isDead();
        if (!GameManager.instance.getPotion())
        {
            Potion_Player.SetActive(false);
        }
        if(!GameManager.instance.getShield())
        {
            Shield_Player.SetActive(false);
        }
    }






    private void OnTriggerEnter2D(Collider2D col)
    {
        //I will handle all the player collisions here and thier affects/abilities
        //1: if player collides with enemy
        //2: if player collides with item/collectable
        //3: if player collides with Scoreincrease
        //4: collectable abilities
        if (col.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.shieldAbility(col);
        }

        if (col.gameObject.CompareTag("Collectable"))
        {
            if (col.gameObject.name == "Coin")
            {
                //increases score
                GameManager.instance.setScore(GameManager.instance.getScore() + 1);
                Destroy(col.gameObject);
                //Debug.Log(GameManager.instance.getScore());
            }
            else if (col.gameObject.name == "Sword")
            {
                //this object will delete/defeat all current enemies
                swordAbility();
                Destroy(col.gameObject);
            }
            else if (col.gameObject.name == "Shield")
            {
                //this object will allow the player to survive one hit
                //this object turns what would have been damage into 1 point
                if(!Shield_Player)
                {
                    Destroy(col.gameObject);
                }
                else
                {
                    Shield_Player.SetActive(true);
                    GameManager.instance.setShield(Shield_Player);
                    Destroy(col.gameObject);
                }

            }
            else if (col.gameObject.name == "Potion")
            {
                //this object will allow the player to heal one HP
                if(!Potion_Player)
                {
                    Destroy(col.gameObject);
                }
                else
                {
                    Potion_Player.SetActive(true);
                    GameManager.instance.setPotion(Potion_Player);
                    Destroy(col.gameObject);

                }
               
            }
        }



    }



    //down below is all collectable abilities

    public void swordAbility()
    {
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (gameObj.name != "Debris")
            {
                Destroy(gameObj);
            }
        }
    }

}
