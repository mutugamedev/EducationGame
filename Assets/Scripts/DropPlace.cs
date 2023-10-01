using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlace : MonoBehaviour
{
    public int ID;
    [HideInInspector] public bool isPlaced;
    [HideInInspector] public bool inRightPlace;

    public void ResetData()
    {
        isPlaced = false;
        inRightPlace = false;
    }
}
