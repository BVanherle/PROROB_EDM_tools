using System.Collections.Generic;
using UnityEngine;
using System.IO;
using EDMTools;

public class PathReader : MonoBehaviour
{
    public PathSpline m_spline;
    [SerializeField]
    public string path;

    // Start is called before the first frame update
    void Awake()
    {
        var keypoints = ReadKeypoints(path);
        m_spline.SetKeypoints(keypoints.Item1, keypoints.Item2);
    }

    private (List<Vector3>, List<Vector3>) ReadKeypoints(string path)
    {
        List<Vector3> points = new List<Vector3>();
        List<Vector3> directions = new List<Vector3>();
        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] split = line.Split(';');
                string posString = split[0];
                string dirString = split[1];

                string[] posSplit = posString.Split(',');
                Vector3 pos = new Vector3(float.Parse(posSplit[0]), float.Parse(posSplit[1]), float.Parse(posSplit[2]));
                points.Add(this.transform.parent.TransformPoint(pos));

                string[] dirSplit = dirString.Split(',');
                Vector3 dir = new Vector3(float.Parse(dirSplit[0]), float.Parse(dirSplit[1]), float.Parse(dirSplit[2]));
                directions.Add(this.transform.parent.TransformDirection(dir));
            }
        }

        return (points, directions);
    }
}