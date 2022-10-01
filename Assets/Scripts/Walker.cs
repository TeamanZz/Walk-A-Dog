using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walker : MonoBehaviour
{
    public Vector2 targetXAllowedValues;
    public Vector2 targetYAllowedValues;
    public Animator animator;
    public List<Rigidbody> rbs = new List<Rigidbody>();
    public List<Collider> colliders = new List<Collider>();
    public CapsuleCollider detectionCollider;
    public Material deathMaterial;
    public GameObject deathFace;
    public List<Material> materials = new List<Material>();

    private DogBase dog;
    private NavMeshAgent agent;
    [SerializeField] private SkinnedMeshRenderer meshRenderer;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        meshRenderer.material = materials[Random.Range(0, materials.Count)];

        foreach (var item in colliders)
        {
            item.enabled = false;
        }

        foreach (var item in rbs)
        {
            item.isKinematic = true;
        }
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
        if (other.gameObject.TryGetComponent<DogBase>(out dog))
        {
            if (!dog.isFlockPart)
                return;

            detectionCollider.enabled = false;
            agent.enabled = false;
            foreach (var item in rbs)
            {
                item.isKinematic = false;
            }

            foreach (var item in colliders)
            {
                item.enabled = true;
            }

            animator.enabled = false;
            foreach (var item in rbs)
            {
                item.AddForce(Vector3.up * 100, ForceMode.Impulse);
            }

            StopAllCoroutines();

            meshRenderer.material = deathMaterial;
            deathFace.SetActive(true);
        }
    }
}