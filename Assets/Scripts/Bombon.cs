using UnityEngine;

public class Bombon : MonoBehaviour
{
    [Header("Megumin Ray")]
    [SerializeField] float sphereCastRad;
    [SerializeField] LayerMask layerMask;

    [Header("Megumin Stats")]
    [SerializeField] int range;
    [SerializeField] float explosionTimer;
    float spawnTimer;

    void OnEnable()
    {
        spawnTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTimer >= explosionTimer) 
        {
            Explode();
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, sphereCastRad);
    }
    void Explode()
    {
        Ray ray = new Ray(transform.position, Vector3.right);
        RaycastHit[] hits = Physics.SphereCastAll(ray, sphereCastRad, range, layerMask);
       // Gizmos.DrawSphere(transform.position, sphereCastRad);
        
        if (hits.Length > 0 )
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

}


