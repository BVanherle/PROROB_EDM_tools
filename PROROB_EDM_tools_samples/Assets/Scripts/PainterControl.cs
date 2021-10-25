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
        painter.SetCurrentTrajectoryID(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount == 500)
        {
            Debug.Log($"Trajectory ID: {painter.GetTrajectoryAtPosition()}");
        }
        if (Time.frameCount == 2000)
        {
            Debug.Log($"Trajectory ID: {painter.GetTrajectoryAtPosition()}");
        }
        if (Time.frameCount == 1000)
        {
            Debug.Log("Switch target");
            painter.SetTargetObject(secondTarget);
            painter.SetCurrentTrajectoryID(2);
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

