using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedProps : Props
{
    private DogBase dog;
    private Rigidbody rb;
    private bool isFixed = true;

    public float flyForce = 1;
    public float torqueForce = 90;

    public GameObject collisionParticle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<DogBase>(out dog))
        {
            Instantiate(collisionParticle, other.transform.position, Quaternion.identity);
            if (isFixed)
            {
                isFixed = false;
                rb.constraints = RigidbodyConstraints.None;
                rb.AddForce(Vector3.up * flyForce, ForceMode.Impulse);
                rb.AddTorque(new Vector3(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f)) * torqueForce, ForceMode.Impulse);
            }
        }
    }
}