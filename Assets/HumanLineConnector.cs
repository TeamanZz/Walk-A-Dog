using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanLineConnector : MonoBehaviour
{
    public List<GameObject> connectedPoints = new List<GameObject>();
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        for (int i = 0; i < connectedPoints.Count; i++)
        {
            lineRenderer.positionCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < connectedPoints.Count; i++)
        {
            lineRenderer.SetPosition(i, connectedPoints[i].transform.position);
        }
    }
}
