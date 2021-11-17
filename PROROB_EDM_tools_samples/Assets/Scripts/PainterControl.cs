using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EDMTools;

public class PainterControl : MonoBehaviour
{
    // Start is called before the first frame update
    public ObjectPainter painter;

    private bool painting = false;
    private int currentTrajectory = 1;

    private Color[] colors = { Color.red, Color.green, Color.blue};
    private int currentColor = 0;

    void Start()
    {
        painter.ShowCursor(true);
        painter.SetCurrentTrajectoryID(currentTrajectory);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.C))
		{
            currentColor++;
            painter.SetColor(colors[currentColor]);
		}
        painter.SetPosition(transform.position, transform.forward);

		if (Input.GetMouseButtonDown(0))
		{
			if (!painting)
			{
                painting = true;
                currentTrajectory++;
                painter.SetCurrentTrajectoryID(currentTrajectory);
			}
        }

		if (Input.GetMouseButtonUp(0))
		{
            painting = false;
		}

		if (painting)
		{
            if (painter.OnTarget())
            {
                painter.CreateStroke();
            }
        }
    }
}

