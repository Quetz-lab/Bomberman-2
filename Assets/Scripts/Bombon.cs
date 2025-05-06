using System;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Bombon : MonoBehaviour
{

    [SerializeField] int gridOffset;
    [SerializeField] int spawnHeigth;

    
    [Header("Megumin Ray")]
    [SerializeField] float sphereCastRad;
    [SerializeField] LayerMask layerMask;

    [Header("Megumin Stats")]
    [SerializeField] int range;
    [SerializeField] float explosionTimer;
    float spawnTimer;
    Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void OnEnable()
    {
        spawnTimer = Time.time;
       Vector2 spawnPos = new Vector2(transform.position.x, transform.position.z);
        int divMain = (int)Mathf.Floor(Mathf.Abs(spawnPos.x / gridOffset));
        float module = spawnPos.x % gridOffset;

        if (Mathf.Abs(module) > gridOffset / 2) divMain++;
        spawnPos.y = divMain * -gridOffset;

        transform.position = new Vector3(spawnPos.x, spawnHeigth, spawnPos.y);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTimer >= explosionTimer) 
        {
            animator.SetTrigger("9_11");
            spawnTimer = Time.time;

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, sphereCastRad);
    }
    public void Explode()
    {
        ExplodeInDirection(Vector3.right);
        ExplodeInDirection(Vector3.left);
        ExplodeInDirection(Vector3.forward);
        ExplodeInDirection(Vector3.back);
    }

    void ExplodeInDirection(Vector3 direction)
    {
        Ray ray = new Ray(transform.position, direction);
        RaycastHit[] hits = Physics.SphereCastAll(ray, sphereCastRad, range, layerMask);
        Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));
        // Gizmos.DrawSphere(transform.position, sphereCastRad);

        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.tag == "Unbreakable") break;
                hit.transform.gameObject.SetActive(false);
                if (hit.transform.tag == "Milenials y Gen Z") break;
            }
        }
    }

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }

}


