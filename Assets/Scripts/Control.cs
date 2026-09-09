using UnityEngine;
using UnityEngine.InputSystem;

public class Control : MonoBehaviour
{
    [SerializeField]
    private int testData = 21;
    public float speed = 5;
    private Vector2 movement;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start invoked");
        //transform.position = new Vector3(4,transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update Invoked.");
        //transform.position = new Vector3(transform.position.x + speed * Time.deltaTime
        //    ,transform.position.y, transform.position.z);
        transform.position = (Vector2) transform.position + movement * Time.deltaTime * speed;
        //new Vector2(transform.position.x + speed * Time.deltaTime
        //    ,transform.position.y);
    }

    void OnMove(InputValue value)
    {
        
        Debug.Log("Attempting to move: " + value.Get<Vector2>());
        movement = value.Get<Vector2>();
    }

    void OnJump()
    {
        Debug.Log("jump!");
    }
}
