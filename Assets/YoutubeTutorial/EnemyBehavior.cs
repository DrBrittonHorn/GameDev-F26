using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 5f;
    public GameObject leftBound;
    public GameObject rightBound;
    public bool isFacingRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingRight)
        {
            // move right
            transform.position = new Vector2(transform.position.x + (speed*Time.deltaTime),
                transform.position.y);
        }
        else
        {
            // move left
            transform.position = new Vector2(transform.position.x - (speed*Time.deltaTime),
                transform.position.y);
        }
        if (transform.position.x > rightBound.transform.position.x)
        {
            isFacingRight = false;
        }
        if (transform.position.x < leftBound.transform.position.x)
        {
            isFacingRight = true;
        }
    }
}
