using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerClass 
{

    private int pos;
    private string name;
    private int score;


    public PlayerClass(int pos, string name, int score)
    {
        this.pos = pos;
        this.name = name;
        this.score = score;
    }



    public int getPos()
    {
        return pos;
    }
    public void setPos(int p)
    {
        pos = p;
    }

    public int getScore()
    {
        return score;
    }
    public void setScore(int s)
    {
        score = s;
    }

    public string getName()
    {
        return name;
    }
    public void setName(string n)
    {
        name = n;
    }





}
