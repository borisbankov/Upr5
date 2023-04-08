using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public float rotateSpeed = 20.0f;
    public float currentDistance = 0.0f;
    public float cameraSpeed = 50.0f;
    public float maxZoom = 3;
    public float minZoom = -3;
    void Start()
    {
        player = GameObject.Find("Player");
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            Quaternion angle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed, Vector3.up);
            offset = angle * offset;

        }

        currentDistance += Input.GetAxisRaw("Mouse ScrollWheel") * cameraSpeed;
        currentDistance = Mathf.Clamp(currentDistance, minZoom, maxZoom);

        transform.position = player.transform.position + offset + currentDistance * transform.forward;

        transform.LookAt(player.transform);

    }
}