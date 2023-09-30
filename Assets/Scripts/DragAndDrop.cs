using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class DragAndDrop : MonoBehaviour
{
    public int ID;

    [HideInInspector]
    public GameObject droppablePosition;
    [HideInInspector]
    public bool isDropped;
    int layerOrder;

    Vector2 resetPos;


    private void Start()
    {
        layerOrder = GetComponent<SpriteRenderer>().sortingOrder;
        resetPos = transform.position;
        if (gameObject.GetComponent<BoxCollider2D>() == null)
            gameObject.AddComponent<BoxCollider2D>();
    }

    public void ResetPosition()
    {
        transform.position = resetPos;
        isDropped = false;
        droppablePosition = null;
    }

    private void OnMouseDrag()
    {
        if (!isDropped)
        {
            Vector2 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;

            GetComponent<SpriteRenderer>().sortingOrder = 10;
        }
    }

    private void OnMouseUp()
    {

        if (!isDropped)
        {
            GetComponent<SpriteRenderer>().sortingOrder = layerOrder;

            if (droppablePosition)
            {
                if (droppablePosition.TryGetComponent(out DropPlace dropPlace) && !dropPlace.isPlaced)
                {
                    transform.position = droppablePosition.transform.position;

                    dropPlace.inRightPlace = ID == droppablePosition.GetComponent<DropPlace>().ID;
                    dropPlace.isPlaced = true;
                    isDropped = true;

                    ButtonFunction.instance.answerList.Add(dropPlace.inRightPlace);
                }
                else
                {
                    ResetPosition();
                }
                Debug.Log(gameObject.name + (dropPlace.inRightPlace ? " in the right place" : " not in the right place"));
            }
            else
            {
                ResetPosition();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        bool inSnapDistance = MathF.Abs(transform.position.x - other.transform.position.x) <= 1f && MathF.Abs(transform.position.y - other.transform.position.y) <= 1f;

        droppablePosition = other.tag == "Drop Here" && inSnapDistance ? other.gameObject : null;
    }
}
