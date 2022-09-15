using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class DogsController : MonoBehaviour
{
    public List<Animator> dogsAnimators = new List<Animator>();
    public List<NavMeshAgent> dogsAgents = new List<NavMeshAgent>();
    public Joystick joystick;
    public GameObject joystickHandle;
    public Transform targetDog;
    public Transform navigationTarget;

    private bool joystickWasDisabled;

    private float movementSpeed;

    private void Update()
    {
        //On Stick Release (1 time)
        if (joystickHandle.activeSelf == false && !joystickWasDisabled)
        {
            for (int i = 0; i < dogsAnimators.Count; i++)
            {
                movementSpeed = dogsAnimators[i].GetFloat("Movement_f");
                DOTween.To(() => movementSpeed, x => movementSpeed = x, 0, 0.5f);
                dogsAgents[i].isStopped = true;
                joystickWasDisabled = true;
            }
        }
        //On Stick hold
        else
        {
            navigationTarget.localPosition = targetDog.position + new Vector3(joystick.Horizontal * 15, 0, joystick.Vertical * 15);

            for (int i = 0; i < dogsAnimators.Count; i++)
            {
                float joystickValue = Mathf.Abs(joystick.Horizontal) + Mathf.Abs(joystick.Vertical);
                dogsAnimators[i].SetFloat("Movement_f", joystickValue);
                dogsAgents[i].isStopped = false;
                dogsAgents[i].speed = joystickValue * 10;
                dogsAgents[i].destination = navigationTarget.position;
            }
            joystickWasDisabled = false;
        }

        //On Stick disabled
        if (joystickHandle.activeSelf == false)
        {
            for (int i = 0; i < dogsAnimators.Count; i++)
            {
                dogsAnimators[i].SetFloat("Movement_f", (movementSpeed));
            }
        }

    }
}