﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {

    private bool isMoving = false;
    private Vector2 mousePosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//has the user selected us?
        if(!isMoving)
        {
            return;
        }

        //get the mouse position in world cooridinates
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //move the sprite with the mouse position
        this.transform.position = new Vector2(mousePosition.x, mousePosition.y);

	}


    private void OnMouseDown()
    {
        if(!DragAndDropManager.instance.isDragging)
        {
            isMoving = true;
            DragAndDropManager.instance.isDragging = true;
        }

    }

    private void OnMouseUp()
    {
        if (DragAndDropManager.instance.isDragging && isMoving == true)
        {
            isMoving = false;
            DragAndDropManager.instance.isDragging = false;
            //check placements
            bool isPlacedOnPlacement = DragAndDropManager.instance.isPlaced(this.gameObject);
            if(isPlacedOnPlacement == false)
            {
                Debug.Log("Placed: " + isPlacedOnPlacement);
            }
        }
    }

    public void OnPlaced(GameObject placement)
    {

        //Debug.Log("OnPlaced: " + placement.name);
    }

}
