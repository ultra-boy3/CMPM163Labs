using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to a GameObject to rotate around the target position.
public class Rotate : MonoBehaviour
{
    GameObject target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Sphere");
        //gameObject.transform.Rotate(Vector3.up, 30);
        //transform.position = new Vector3(20, 2, 20);
    }

    void Update()
    {
        // Spin the object around the world origin at 20 degrees/second.
        gameObject.transform.RotateAround(target.transform.position, transform.up, 30 * Time.deltaTime);
    }
}