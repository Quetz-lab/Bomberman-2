using UnityEngine;

public class GMBomb : MonoBehaviour
{
    InputManager manager;
    public GameObject bombPrefab;

    private void Awake()
    {
        manager = GetComponent<InputManager>();
    }

    void OnEnable()
    {
        manager.OnBombPressed.AddListener(DeployBomb);
    }

    private void OnDisable()
    {
        manager.OnBombPressed.RemoveListener(DeployBomb);
    }

    private void DeployBomb()
    {
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
