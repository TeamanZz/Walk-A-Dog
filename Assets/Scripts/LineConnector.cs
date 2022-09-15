using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnector : MonoBehaviour
{
    public List<GameObject> connectedPoints = new List<GameObject>();
    private LineRenderer dogsLineRenderer;

    void Start()
    {
        dogsLineRenderer = GetComponent<LineRenderer>();
        connectedPoints.Insert(0, gameObject);
        for (int i = 0; i < connectedPoints.Count; i++)
        {
            dogsLineRenderer.positionCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < connectedPoints.Count; i++)
        {
            dogsLineRenderer.SetPosition(i, connectedPoints[i].transform.position);
        }
    }
}