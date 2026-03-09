using UnityEngine;

public class Dragable : MonoBehaviour
{
    private Camera cam;
    private bool dragging;
    private Vector3 offset;

    void Start()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        dragging = true;

        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, transform.position.z);
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (!dragging) return;

        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 target = new Vector3(mousePos.x, mousePos.y, transform.position.z) + offset;

        transform.position = target;
    }
}