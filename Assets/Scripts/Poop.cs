using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    private Rigidbody rb;
    public float flyForce = 1;
    public float torqueForce = 90;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(Vector3.up * flyForce, ForceMode.Impulse);
        rb.AddTorque(new Vector3(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f)) * torqueForce, ForceMode.Impulse);
    }

}
