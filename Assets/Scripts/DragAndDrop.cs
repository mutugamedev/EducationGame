using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DragAndDrop : MonoBehaviour
{
    public GameObject droppablePosition;
    private bool isMoving;

    private Vector2 startPos, resetPos;

    // Start is called before the first frame update
    private void Start()
    {
        resetPos = transform.localPosition;
        if (gameObject.GetComponent<BoxCollider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            gameObject.transform.localPosition = new Vector2(mousePos.x - startPos.x, mousePos.y - startPos.y);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPos.x = mousePos.x - transform.localPosition.x;
            startPos.y = mousePos.y - transform.localPosition.y;

            isMoving = true;
        }
    }

    private void OnMouseUp()
    {
        isMoving = false;

        if (droppablePosition != null &&
                MathF.Abs(transform.localPosition.x - droppablePosition.transform.localPosition.x) <= 0.5f &&
                MathF.Abs(transform.localPosition.y - droppablePosition.transform.localPosition.y) <= 0.5f)
        {
            transform.position = new Vector2(droppablePosition.transform.position.x, droppablePosition.transform.position.y);
        }
        else
        {
            transform.localPosition = new Vector2(resetPos.x, resetPos.y);
        }
    }
}
