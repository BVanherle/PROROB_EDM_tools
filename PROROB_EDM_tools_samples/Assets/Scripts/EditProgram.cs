using EDMTools;
using UnityEngine;
using Prorob.Model;

public class EditProgram : MonoBehaviour
{
    public GameObject m_targetObject;
    public GameObject m_controller;

    private EDMTools.EditTool m_editTool = null;
    private RobotPath m_robothPath;
    private Trajectory m_trajectory;

    void Start()
    {
        PathCreator creator = new PathCreator(m_targetObject);
        m_trajectory = creator.GetTrajectory();

        m_robothPath = gameObject.AddComponent<RobotPath>();
        m_robothPath.SetTrajectory(m_trajectory);
    }

    private void FinishEdit(TrajectorySection manipulatedSection)
    {
        m_trajectory = manipulatedSection.Trajectory;
        m_robothPath.SetTrajectory(m_trajectory);
        GameObject.Destroy(m_editTool.gameObject);
        m_editTool = null;
    }

    private ManipulatableTrajectorySection GetSection()
    {
        TrajectorySection section = new TrajectorySection(m_trajectory, new IndexRange(40, 10));
        ManipulatableTrajectorySection manipulatableSection = new ManipulatableTrajectorySection(section, 45);
        return manipulatableSection;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_editTool?.GrabReleased();
            GameObject editToolGO = new GameObject("Distance Edit Tool");
            m_editTool = editToolGO.AddComponent<EDMTools.DistanceEditTool>();
            m_editTool.ManipulationFinished += FinishEdit;
            m_editTool.Init(GetSection(), m_targetObject);

        } else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_editTool?.GrabReleased();
            GameObject editToolGO = new GameObject("Free form edit tool");
            m_editTool = editToolGO.AddComponent<EDMTools.FreeFormEditTool>();
            m_editTool.ManipulationFinished += FinishEdit;
            m_editTool.Init(GetSection(), m_targetObject);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            m_editTool?.GrabReleased();
            GameObject editToolGO = new GameObject("Direction edit tool");
            m_editTool = editToolGO.AddComponent<EDMTools.DirectionEditTool>();
            m_editTool.ManipulationFinished += FinishEdit;
            m_editTool.Init(GetSection(), m_targetObject);
        }
        m_editTool?.UpdateControllerPose(m_controller.transform);
        m_editTool?.GrabPressed();
    }
}
