using UnityEngine;

public class CollectableController : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D CRB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }


    private void movement()
    {
        CRB.linearVelocity = new Vector2(Speed * -1, 0);
    }

}
