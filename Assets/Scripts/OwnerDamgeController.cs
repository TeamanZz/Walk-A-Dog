using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerDamgeController : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Props props;
        DogBase dog;
        if (other.gameObject.TryGetComponent<Props>(out props)
        || other.gameObject.TryGetComponent<DogBase>(out dog))
        {
            float velocity = Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y) + Mathf.Abs(rb.velocity.z);
            if (velocity > 6)
                DogOwner.Instance.SpawnRandomPopup();
        }
    }
}