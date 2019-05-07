using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusController : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private bool isCanvasVisible;
    private Canvas canvas;
    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        canvas = this.GetComponentInChildren<Canvas>();
        collider = GetComponent<Collider2D>();
        canvas.enabled = false;
        isCanvasVisible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 tf = Camera.main.ScreenToWorldPoint(touch.position);
            if (collider.OverlapPoint(new Vector2(tf.x, tf.y)) && Time.deltaTime >= 1)
            {
                DisplayRouteOptions();
            }
        }
    }

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - 
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        transform.position = curPosition;
    }

    private void DisplayRouteOptions()
    {
        if (!isCanvasVisible)
        {
            canvas.enabled = true;
            isCanvasVisible = true;
        }
        else
        {
            canvas.enabled = false;
            isCanvasVisible = false;
        }
    }
}
