using Prorob.Model;
using UnityEngine;
using System.Collections.Generic;

public class RobotPath : MonoBehaviour
{
    private Trajectory m_trajctory;
    private LineRenderer m_lineRenderer;

    public void SetTrajectory(Trajectory trajectory)
    {
        m_trajctory = trajectory;
        m_lineRenderer = CreateLineRenderer(trajectory.KeyFrames.Count);
        UpdateTrajectory();
    }

    public void UpdateTrajectory()
    {
        List<Vector3> positions = new List<Vector3>();
        foreach(var kf in m_trajctory.KeyFrames)
        {
            positions.Add(kf.Value.Position);
        }
        m_lineRenderer.SetPositions(positions.ToArray());
    }

    private LineRenderer CreateLineRenderer(int size)
    {
        if(m_lineRenderer != null)
        {
            Destroy(m_lineRenderer);
        }
        GameObject lineObject = new GameObject("Line");
        LineRenderer renderer = lineObject.AddComponent<LineRenderer>();
        renderer.material = new Material(Shader.Find("Sprites/Default"));
        renderer.widthMultiplier = 0.5f;
        renderer.positionCount = size;

        renderer.startWidth = 0.005f;
        renderer.endWidth = 0.005f;
        renderer.startColor = Color.red;
        renderer.endColor = Color.red;
        renderer.loop = false;

        return renderer;
    }
}
