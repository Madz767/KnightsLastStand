using UnityEngine;

public class DeathBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("I have Collided");
        Destroy(collision.gameObject);
    }
}
