using UnityEngine;
using System.Collections.Generic;

public class GMBomb : MonoBehaviour
{
    InputManager manager;
    public GameObject bombPrefab;
    [SerializeField] Transform bombPoolParent;
    [Header("Bomb Stats")]
    [SerializeField] int maxBombs;
    [SerializeField] int bombRange;
    List<GameObject> bombsPool = new List<GameObject>();

    private void Awake()
    {
        manager = GetComponent<InputManager>();
    }

    private void Start()
    {
        for (int i = 0; i < maxBombs; i++) { GameObject bomb = Instantiate(bombPrefab, bombPoolParent);
            bomb.SetActive(false);
            bombsPool.Add(bomb);
        }
    }

    void OnEnable()
    {
        manager.OnBombPressed.AddListener(DeployBomb);
    }

    private void OnDisable()
    {
        maxBombs = 1;
        bombRange = 1;
        manager.OnBombPressed.RemoveListener(DeployBomb); 
    }

    private void DeployBomb()
    {
        foreach (GameObject bomb in bombsPool)
        { if (bomb.activeSelf) continue;
            bomb.transform.position = transform.position;
            bomb.GetComponent<Bombon>().SetBombRange(bombRange);
            bomb.SetActive (true);
            return;
        }
        //Instantiate(bombPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame

    void Update()
    {
        
    }


    public void AddExtraBomb()
    {
        maxBombs++;
        GameObject bomb = Instantiate(bombPrefab, bombPoolParent);
        bomb.SetActive(false);
        bombsPool.Add(bomb);
    }

    public void AddExtraRange()
    {
        bombRange++;
    }
}
