using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EDMTools;

public class PainterControl : MonoBehaviour
{
    public struct PaintInstruction
    {
        public Vector3 position;
        public Vector3 direction;
        public Color color;
        public float brushSize;
        public int trajectoryID;

        public PaintInstruction(Vector3 position, Vector3 direction, Color color, float brushSize, int trajectoryID)
        {
            this.position = position;
            this.direction = direction;
            this.color = color;
            this.brushSize = brushSize;
            this.trajectoryID = trajectoryID;
        }
    }


    public ObjectPainter painter;

    private bool painting = false;
    private int currentTrajectory = 1;

    private Color[] colors = { Color.red, Color.green, Color.blue};
    private int currentColor = 0;

    private List<PaintInstruction> instructions;

    void Start()
    {
        instructions = new List<PaintInstruction>();
        painter.ShowCursor(true);
        painter.SetCurrentTrajectoryID(currentTrajectory);
    }

    // Update is called once per frame
    void Update()
    {
        painter.SetPosition(transform.position, transform.forward);

        if (Input.GetKeyDown(KeyCode.C))
		{
            currentColor++;
		}

		if (Input.GetMouseButtonDown(0))
		{
			if (!painting)
			{
                painting = true;
                currentTrajectory++;
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
                instructions.Add(new PaintInstruction(transform.position, transform.forward, colors[currentColor], painter.GetBrushSize(), currentTrajectory)) ;
            }
        }

        Draw();
    }

    private void Draw()
    {
        painter.ResetPaint();
        foreach(var instruction in instructions)
        {
            painter.SetBrushSize(instruction.brushSize);
            painter.SetColor(instruction.color);
            painter.SetCurrentTrajectoryID(instruction.trajectoryID);
            painter.SetPosition(instruction.position, instruction.direction);
            painter.CreateStroke();
        }
    }
}

