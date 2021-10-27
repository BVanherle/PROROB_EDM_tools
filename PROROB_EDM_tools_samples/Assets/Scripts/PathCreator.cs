using Prorob.Model;
using UnityEngine;

class PathCreator
{
    private GameObject m_targetObject;

    public PathCreator(GameObject target)
    {
        m_targetObject = target;
    }

    public Trajectory GetTrajectory()
    {
        Bounds bounds = m_targetObject.GetComponent<MeshRenderer>().bounds;
        Vector3 topLeft = new Vector3(bounds.min.x, bounds.max.y, bounds.min.z - 0.1f);
        Vector3 bottomRight = new Vector3(bounds.max.x, bounds.min.y, bounds.min.z - 0.1f);
        Vector3 center = Vector3.Lerp(topLeft, bottomRight, 0.5f);
        Quaternion direction = Quaternion.LookRotation(bounds.center - center);

        Trajectory trajectory = new Trajectory();

        for (int i = 0; i < 100; i++)
        {
            Vector3 position = Vector3.Lerp(topLeft, bottomRight, i / 100f); 
            KeyFrame<Prorob.Model.Pose> keyframe = new KeyFrame<Prorob.Model.Pose>(i, new Prorob.Model.Pose(position, direction));
            trajectory.KeyFrames.Add(keyframe);
        }


        return trajectory;
    }
    
}
