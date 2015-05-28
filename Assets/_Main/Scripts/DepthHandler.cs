using UnityEngine;
using System.Collections;

public class DepthHandler : Singleton<DepthHandler> {

    //public float CalibratedDepth; // Not being used;
    public float AverageDepth;
    public float LowestDepth;
    public int LowestDepthIndex;
    public float GreatestDepth;

    [Range(0, 1)]
    public float tempX01;
    [Range(0, 1)]
    public float tempY01;

    public Transform SphereTransform;
    public ZigResolution TextureSize = ZigResolution.QQVGA_160x120;
    ResolutionData textureSize;

	// Use this for initialization
	void Start () {
        textureSize = ResolutionData.FromZigResolution(TextureSize);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reset LowestDepth");
            LowestDepth = Mathf.Infinity;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Set Max Depth");
            GreatestDepth = AverageDepth/27f;
        }
	}

    public void UpdateLowestDepthAndAverage(float average, float lowestDepth, int lowestDepthIndex)
    {
        AverageDepth = average;
        LowestDepth = lowestDepth;
        LowestDepthIndex = lowestDepthIndex;

        SphereTransform.position = GetHighestPoint();

        Debug.Log(
            "Average: " + average +
            ", Lowest: " + lowestDepth +
            ", Lowest Index: " + lowestDepthIndex);
    }

    private Vector3 GetHighestPoint()
    {
        Vector2 vCor = GetViewportCoordinates(LowestDepthIndex);
        return Camera.main.ViewportToWorldPoint(new Vector3(vCor.x, vCor.y, Mathf.Lerp(0, 9.077077f, LowestDepth / GreatestDepth)));
    }

    private Vector2 GetViewportCoordinates(int index)
    {
        Vector2 vCor = Vector2.zero;
        int linesDownward = (index / textureSize.Width);
        int linesSideward = (index % textureSize.Width);
        vCor.y = (float)linesDownward / (float)textureSize.Height; // Percentage downward.
        vCor.x = (float)linesSideward / (float)textureSize.Width; // Percentage upward.

        Debug.Log("Index; " + index + ", \n"
        + " Width: " + textureSize.Width + ", Height: " + textureSize.Height);
        Debug.Log("Amount Down: " + linesDownward + ", Amount Sideways: " + linesSideward);
        return vCor;
        //return new Vector2(tempX01, tempY01);
    }
}
