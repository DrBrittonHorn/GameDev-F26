using UnityEngine;
using UnityEngine.InputSystem;

public class LeeroyControl : MonoBehaviour
{
    public GameObject leeroy;
    private Vector2 mousePos;
    private Vector2 startClick;
    public float power;
    public float maxPull;
    private Vector2 initLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initLocation = leeroy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseMove(InputValue value)
    {
        mousePos = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
    }

    void OnMouseClick(InputValue value)
    {
        if (value.isPressed)
        {
            startClick = mousePos;
        } else
        {
            // set to dyanmic
            // calculate direction and power
            Vector2 releasePos = mousePos;
            Vector2 dir = releasePos - startClick;
            float dragDist = Mathf.Min(dir.magnitude,maxPull);
            Vector2 launch = startClick - releasePos;
            Rigidbody2D leeroyRB = leeroy.GetComponent<Rigidbody2D>();
            leeroyRB.bodyType = RigidbodyType2D.Dynamic;
            leeroyRB.AddForce(launch * power, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Ground"))
        {
            leeroy.transform.position = initLocation;
            leeroy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
