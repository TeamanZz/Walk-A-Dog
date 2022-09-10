using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogsController : MonoBehaviour
{
    public List<Animator> dogsAnimators = new List<Animator>();
    public List<NavMeshAgent> dogsAgents = new List<NavMeshAgent>();
    public Joystick joystick;
    public GameObject joystickHandle;
    public Transform targetDog;
    public Transform navigationTarget;

    private void Update()
    {
        if (joystickHandle.activeSelf == false)
        {
            for (int i = 0; i < dogsAnimators.Count; i++)
            {
                dogsAnimators[i].SetFloat("Speed_f", (0));
                dogsAgents[i].isStopped = true;
            }
            return;
        }


        navigationTarget.localPosition = targetDog.position + new Vector3(joystick.Horizontal * 15, 0, joystick.Vertical * 15);

        for (int i = 0; i < dogsAnimators.Count; i++)
        {
            dogsAnimators[i].SetFloat("Speed_f", (1));
            dogsAgents[i].isStopped = false;
            dogsAgents[i].destination = navigationTarget.position;
        }
    }
}