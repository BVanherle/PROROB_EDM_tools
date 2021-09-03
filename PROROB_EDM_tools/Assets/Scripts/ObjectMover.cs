using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public Vector3 speed = new Vector3(0.1f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed;
        Debug.DrawRay(transform.position, transform.forward, Color.red, 0f, true);
    }
}
