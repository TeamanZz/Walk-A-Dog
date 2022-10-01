using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walker : MonoBehaviour
{
    private NavMeshAgent agent;

    public Vector2 targetXAllowedValues;
    public Vector2 targetYAllowedValues;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        Vector3 targetPos = new Vector3(Random.Range(targetXAllowedValues.x, targetXAllowedValues.y), transform.position.y, Random.Range(targetYAllowedValues.x, targetYAllowedValues.y));
        agent.destination = targetPos;
        StartCoroutine(SetNewDestination());
    }

    private IEnumerator SetNewDestination()
    {
        yield return new WaitForSeconds(Random.Range(8, 20));
        Vector3 targetPos = new Vector3(Random.Range(targetXAllowedValues.x, targetXAllowedValues.y), transform.position.y, Random.Range(targetYAllowedValues.x, targetYAllowedValues.y));
        agent.destination = targetPos;
        yield return SetNewDestination();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("asasa");
    }
}