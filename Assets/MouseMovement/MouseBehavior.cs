using UnityEngine;
using UnityEngine.InputSystem;

public class MouseBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMousePos(InputValue value)
    {
        Debug.Log("position: " + value.Get<Vector2>());
        transform.position = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
    }
}
