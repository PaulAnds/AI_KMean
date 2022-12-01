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
        if (isMoving)
        {
            currentTouch = (touchedHere - transform.position).magnitude;
        }
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                prevTouch = 0;
                currentTouch = 0;
                isMoving = true;
                touchedHere = Camera.main.ScreenToWorldPoint(touch.position);
                touchedHere.y = 0;
                desiredPosition = (touchedHere - transform.position).normalized;
                RB.velocity = new Vector3(desiredPosition.x * Speed, 0.0f, desiredPosition.z * Speed);
            }
        }
        if(currentTouch > prevTouch)
        {
            isMoving = false;
            RB.velocity = Vector3.zero;
        }
        if (isMoving)
        {
            prevTouch = (touchedHere - transform.position).magnitude;
        }
    }
}
