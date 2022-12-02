using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody RB;

    private Touch touch;
    private Vector3 touchedHere, desiredPosition;
    public float Speed = 20;
    private bool isMoving = false;

    float prevTouch, currentTouch;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isMoving)
        {   //gets the distance between the GO and where you touch
            currentTouch = (touchedHere - transform.position).magnitude;
        }
        if(Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                prevTouch = 0;
                currentTouch = 0;
                isMoving = true;
                //gets the position in which you touched
                touchedHere = Camera.main.ScreenToWorldPoint(touch.position);
                touchedHere.y = 0;
                desiredPosition = (touchedHere - transform.position).normalized;
                //moves the GO to said position
                RB.velocity = new Vector3(desiredPosition.x * Speed, 0.0f, desiredPosition.z * Speed);
            }
        }
        //will stop moving once the GO is in said position
        if(currentTouch > prevTouch)
        {
            isMoving = false;
            RB.velocity = Vector3.zero;
        }
        //saves the last area you moved too
        if (isMoving)
        {
            prevTouch = (touchedHere - transform.position).magnitude;
        }
        */
    }
}
