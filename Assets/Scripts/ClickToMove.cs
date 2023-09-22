using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ClickToMove : MonoBehaviour
{
   public GameObject target;
   public float speed;
   public Vector3 moveToPosition;

   void Start()
   {
      moveToPosition = transform.position;
   }

   void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         RaycastHit2D hit = Physics2D.Raycast(raycastPosition, Vector2.zero);

         if (hit.collider != null)
         {
            if (hit.collider.gameObject.tag == "Player")
            {
               target = hit.collider.gameObject;
            }
         }
      }

      if (Input.GetMouseButtonDown(0))
      {
         moveToPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         moveToPosition.z = transform.position.z;
      }

      if (target != null) 
      {
         target.transform.position = Vector3.MoveTowards(target.transform.position, moveToPosition, speed * Time.deltaTime);
      }
   }
}