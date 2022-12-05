using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Touch touch;
    private Vector3 touchedHere;
    private bool canMove = false;
    // Update is called once per frame

    void Update()
    {
        if(canMove){
            if(Input.touchCount == 1)
            {
                touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Began)
                {
                //gets the position in which you touched
                    touchedHere = Camera.main.ScreenToWorldPoint(touch.position);
                    transform.position = new Vector3(touchedHere.x,0.9f,touchedHere.z);
                    canMove=false;
                }
            }
        }
    }

    public void MoveBase(){
        canMove = true;
    }
}
