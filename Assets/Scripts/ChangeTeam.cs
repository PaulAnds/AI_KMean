using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTeam : MonoBehaviour
{
    [Header("Base RGBP")]
    public GameObject Red_Base;
    public GameObject Green_Base;
    public GameObject Blue_Base;
    public GameObject Purple_Base;

    [Header("Materials RGBP")]
    public Material[] newMaterialRef;


    // Start is called before the first frame update
    void Start()
    {
        Red_Base = GameObject.FindWithTag("Red_Base");
        Green_Base = GameObject.FindWithTag("Green_Base");
        Blue_Base = GameObject.FindWithTag("Blue_Base");
        Purple_Base = GameObject.FindWithTag("Purple_Base");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, Red_Base.transform.position) < Vector3.Distance(transform.position, Green_Base.transform.position) &&
            Vector3.Distance(transform.position, Red_Base.transform.position) < Vector3.Distance(transform.position, Blue_Base.transform.position) &&
             Vector3.Distance(transform.position, Red_Base.transform.position) < Vector3.Distance(transform.position, Purple_Base.transform.position))
        {
            GetComponentInChildren<Renderer>().material = newMaterialRef[0];
        }
        else if (Vector3.Distance(transform.position, Green_Base.transform.position) < Vector3.Distance(transform.position, Red_Base.transform.position) &&
            Vector3.Distance(transform.position, Green_Base.transform.position) < Vector3.Distance(transform.position, Blue_Base.transform.position) &&
             Vector3.Distance(transform.position, Green_Base.transform.position) < Vector3.Distance(transform.position, Purple_Base.transform.position))
        {
            GetComponentInChildren<Renderer>().material = newMaterialRef[1];
        }
        else if(Vector3.Distance(transform.position, Blue_Base.transform.position) < Vector3.Distance(transform.position, Green_Base.transform.position) &&
            Vector3.Distance(transform.position, Blue_Base.transform.position) < Vector3.Distance(transform.position, Red_Base.transform.position) &&
             Vector3.Distance(transform.position, Blue_Base.transform.position) < Vector3.Distance(transform.position, Purple_Base.transform.position))
        {
            GetComponentInChildren<Renderer>().material = newMaterialRef[2];
        }
        else
        {
            GetComponentInChildren<Renderer>().material = newMaterialRef[3];
        }
    }
}
