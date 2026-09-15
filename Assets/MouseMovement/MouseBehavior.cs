using UnityEngine;
using UnityEngine.InputSystem;

public class MouseBehavior : MonoBehaviour
{
    public GameObject thingToMake;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("MakeStuff", 2f, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMousePos(InputValue value)
    {
        Debug.Log("position: " + value.Get<Vector2>());
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
        transform.position = mousePos;
        Debug.Log("Triangle position: " + transform.position);
    }

    void MakeStuff()
    {
        Instantiate(thingToMake, transform.position, Quaternion.identity);
    }
}
