using UnityEngine;
using System.Collections;

public class CalibrationHandler : Singleton<CalibrationHandler> {

    public Transform Skeleton_LeftMiddleFingerTip;
    public Transform Skeleton_RightMiddleFingerTip;
    public Transform Table;
    public Transform TableMesh;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CalibrateTablePos();
        }
    }

    private void CalibrateTablePos()
    {
        Table.position = Vector3.Lerp(Skeleton_LeftMiddleFingerTip.position, Skeleton_RightMiddleFingerTip.position, 0.5f) - new Vector3(0, TableMesh.transform.localScale.y/2f, 0);
    }
}
