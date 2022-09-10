using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnector : MonoBehaviour
{
    public List<GameObject> connectedPoints = new List<GameObject>();
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
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
