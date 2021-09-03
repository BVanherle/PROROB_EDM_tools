using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EDMTools;

public class PainterControl : MonoBehaviour
{
    // Start is called before the first frame update
    public ObjectPainter painter;

    void Start()
    {
        painter.ShowCursor(true);
    }

    // Update is called once per frame
    void Update()
    {
        painter.SetPosition(transform.position, transform.forward);
        if (painter.OnTarget())
        {
            painter.CreateStroke();
        } else
        {
            Debug.Log("Paint missed target");
        }
        
    }
}

