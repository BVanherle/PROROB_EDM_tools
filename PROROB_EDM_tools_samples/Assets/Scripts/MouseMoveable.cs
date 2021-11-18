using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoveable : MonoBehaviour
{
    private float z;

    void Start()
    {
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -z);
        Vector3 pos = Camera.main.ScreenToWorldPoint(vector);
        pos.z = z;
        transform.position = pos;
    }
}
