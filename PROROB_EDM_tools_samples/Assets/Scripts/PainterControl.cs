using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EDMTools;

public class PainterControl : MonoBehaviour
{
    // Start is called before the first frame update
    public ObjectPainter painter;
    public GameObject secondTarget;

    void Start()
    {
        painter.ShowCursor(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount == 1000)
        {
            Debug.Log("Switch target");
            painter.SetTargetObject(secondTarget);
        }
        painter.SetPosition(transform.position, transform.forward);
        if (painter.OnTarget())
        {
            painter.SetPaintSpeed(Time.frameCount / 3000f);
            painter.SetColor(Color.Lerp(Color.magenta, Color.cyan, Time.frameCount / 3000f));
            painter.CreateStroke();
        }
    }
}

