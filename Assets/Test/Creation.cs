using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Creation : MonoBehaviour
{
    public GameObject objToMake;
    public float delay;
    public float startDelay;
    private Vector2 mousePos;
    private Vector2 startPos;
    private Vector2 releasePos;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //InvokeRepeating("makeObjects", 1f, .5f);
        StartCoroutine(makeObjectsEnumerator(startDelay, delay));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void makeObjects()
    {
        Instantiate(objToMake, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
    }
    private IEnumerator makeObjectsEnumerator(float startDelay, float delay)
    {
        yield return new WaitForSeconds(startDelay);
        while(true)
        {
            Instantiate(objToMake, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }

    void OnMouseMove(InputValue value)
    {
        mousePos = value.Get<Vector2>();
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    void OnMouseClick(InputValue value)
    {
        if (value.isPressed)
        {
            transform.position = Vector2.zero;
            startPos = mousePos;
            releasePos = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static;
        } else
        {
            releasePos = mousePos;
            Vector2 dir = releasePos - startPos;
            float dragDist = Mathf.Min(dir.magnitude, 3);
            Vector2 launch = startPos - releasePos;   // opposite the drag, magnitude = pull distance
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(launch * 2, ForceMode2D.Impulse);
        }
    }
}
