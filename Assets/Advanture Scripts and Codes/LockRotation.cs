using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockRotation : MonoBehaviour
{
    //public Canvas nameLable;
    //// Update is called once per frame
    //void Update()
    //{
    //    Vector3 namePose = Camera.main.WorldToScreenPoint(this.transform.position);
    //    nameLable.transform.position = namePose;
    //}

    public Transform target;
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(target.position);
        Debug.Log("target is " + screenPos.x + " pixels from the left");
    }
}