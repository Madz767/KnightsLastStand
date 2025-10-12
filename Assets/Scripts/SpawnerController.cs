using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    //these are the spawn points
    public GameObject HighestSpawn;
    public GameObject LowestSpawn;


    //these are the objects it will spawn
    
    //collectables
    public GameObject Shield;
    public GameObject Sword;
    public GameObject Coin;
    public GameObject Potion;

    //enemies
    public GameObject Knight;
    public GameObject Arrow;
    public GameObject Debris;

    //which object will be spawned
    private GameObject objToSpawn;

    //variables to deal with timing and random spawns
    private int randoTime;
    private float time;
    public float delay;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= delay)
        {
            spawnObject();
            time = 0f;


        }

    }



    private void spawnObject()
    {

        randoTime = Random.Range(0, 7);
        //I alternated the collectables and enemies
        //below to try and achieve even more random events
        if (randoTime == 0)
        {
            objToSpawn = Instantiate(Shield);
        }
        else if (randoTime == 1)
        {
            objToSpawn = Instantiate(Knight);
        }
        else if (randoTime == 2)
        {
            objToSpawn = Instantiate(Coin);
        }
        else if (randoTime == 3)
        {
            objToSpawn = Instantiate(Arrow);
        }
        else if (randoTime == 4)
        {
            objToSpawn = Instantiate(Sword);
        }
        else if (randoTime == 5)
        {
            objToSpawn = Instantiate(Debris);
        }
        else if (randoTime == 6)
        {
            objToSpawn = Instantiate(Potion);
        }

        objToSpawn.transform.position = new Vector2(LowestSpawn.transform.position.x, Random.Range(LowestSpawn.transform.position.y, HighestSpawn.transform.position.y));


    }








}
