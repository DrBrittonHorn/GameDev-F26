using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollow : MonoBehaviour
{
    private Vector2 mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mousePos;
    }

    void OnMouseMove(InputValue value)
    {
        mousePos = value.Get<Vector2>();
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
