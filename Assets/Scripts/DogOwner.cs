using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogOwner : MonoBehaviour
{
    public static DogOwner Instance;
    public List<GameObject> damagePopupParticles = new List<GameObject>();
    public Transform ownerPosition;
    public float particleCooldown = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SpawnRandomPopup();
        }
        particleCooldown -= Time.deltaTime;
    }

    public void SpawnRandomPopup()
    {
        if (particleCooldown <= 0)
        {
            int index = Random.Range(0, damagePopupParticles.Count);
            Instantiate(damagePopupParticles[index], ownerPosition.position + new Vector3(0, 2, 0), Quaternion.identity);
            particleCooldown = 0.5f;
        }
    }
}