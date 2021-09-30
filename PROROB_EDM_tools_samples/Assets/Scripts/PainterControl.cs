using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EDMTools;

public class PainterControl : MonoBehaviour
{
    // Start is called before the first frame update
    public ObjectPainter painter;
    private int m_paintHits = 0;

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
            m_paintHits++;
            painter.SetColor(Color.Lerp(Color.magenta, Color.cyan, m_paintHits/1000f));
            painter.CreateStroke();
        } else
        {
            Debug.Log("Paint missed target");
        }
        
    }
}

