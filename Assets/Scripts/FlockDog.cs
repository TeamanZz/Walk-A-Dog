using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockDog : DogBase
{
    public GameObject takeParticle;
    public GameObject poopPrefab;
    public Transform poopPosition;

    private Animator animator;
    private DogBase dog;
    private bool isTriggered = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("ActionType_int", Random.Range(1, 14));
    }

    private void Start()
    {
        StartCoroutine(SpawnPoop());
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered)
            return;

        if (other.TryGetComponent<DogBase>(out dog))
        {
            isTriggered = true;
            animator.SetInteger("ActionType_int", 0);
            animator.Rebind();
            DogsController.Instance.AddDogToFlock(this.gameObject);

            Instantiate(takeParticle, transform.position + new Vector3(0, 0.3f, 0), Quaternion.Euler(-90, 0, 0));
        }
    }

    private IEnumerator SpawnPoop()
    {
        yield return new WaitForSeconds(Random.Range(8, 20));
        if (isTriggered)
        {
            var poop = Instantiate(poopPrefab, poopPosition.position, Quaternion.identity);
            poop.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
        yield return SpawnPoop();
    }
}