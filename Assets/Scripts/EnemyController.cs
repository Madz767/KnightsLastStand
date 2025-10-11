using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float Speed;
    private Rigidbody2D ERB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ERB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }


    private void movement()
    {
        ERB.linearVelocity = new Vector2(Speed * -1, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

}
