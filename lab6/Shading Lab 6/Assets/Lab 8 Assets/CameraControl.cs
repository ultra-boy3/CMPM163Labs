using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float sensitivity = 100f;
    public float speed = 5f;
    public bool rotateY = false;

    //public Transform playerBody;
    float xRotation = 0f;
    float yRotation = 0f;
    CharacterController cc;

    //Transform self = GameObject.GetComponent(Transform);

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation += mouseX;

        //cc.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        Vector3 movement = new Vector3();
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        cc.Move(speed * gameObject.transform.forward * movement.z);
        cc.Move(speed * gameObject.transform.right * movement.x);
    }
}