using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockDog : MonoBehaviour
{
    private MainDog mainDog;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("ActionType_int", Random.Range(1, 14));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MainDog>(out mainDog))
        {
            animator.SetInteger("ActionType_int", 0);
            animator.Rebind();
            DogsController.Instance.AddDogToFlock(this.gameObject);
        }
    }
}