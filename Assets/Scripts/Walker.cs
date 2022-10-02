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
    private DemolitionBehaivor demolitionBehaivor;

    public WalkerState walkerState;

    public float stoppingDistance = 1;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        demolitionBehaivor = GetComponent<DemolitionBehaivor>();
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
        SetNewDestination();
        StartCoroutine(SetNewDestinationInLoop());
    }

    private void Update()
    {
        if (agent.remainingDistance >= 0.5f
        && walkerState == WalkerState.Walk
        && agent.remainingDistance <= stoppingDistance)
        {
            ChangeState(WalkerState.Idle);
        }
    }

    private IEnumerator SetNewDestinationInLoop()
    {
        yield return new WaitForSeconds(Random.Range(8, 20));
        SetNewDestination();
        yield return SetNewDestinationInLoop();
    }

    private void SetNewDestination()
    {
        Vector3 targetPos = new Vector3(Random.Range(targetXAllowedValues.x, targetXAllowedValues.y), transform.position.y, Random.Range(targetYAllowedValues.x, targetYAllowedValues.y));
        agent.destination = targetPos;
        ChangeState(WalkerState.Walk);
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
            demolitionBehaivor.IncreaseDemolition();

            this.enabled = false;
        }
    }

    private void ChangeState(WalkerState newState)
    {
        walkerState = newState;
        if (walkerState == WalkerState.Idle)
        {
            animator.SetBool("IsWalking", false);
        }
        else
        {
            animator.SetBool("IsWalking", true);
        }
    }

    public enum WalkerState
    {
        Idle,
        Walk
    }
}