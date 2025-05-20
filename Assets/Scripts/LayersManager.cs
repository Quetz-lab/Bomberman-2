using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class LayersManager : MonoBehaviour
{
    //PlayerManagerxd
    PlayerInputManager playerInputManager;
    [SerializeField] List<Transform> spawnPos;
    [SerializeField] List<Material> playerMat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        
    }

    public void OnPlayerJoin(PlayerInput player)
    {
        Debug.Log("Player has Joined");
        player.gameObject.transform.position = spawnPos[playerInputManager.playerCount - 1].position;
        player.gameObject.GetComponent<MeshRenderer>().material = playerMat[playerInputManager.playerCount - 1];
    }
    public void OnPlayerLeft(PlayerInput player)
    {
        Debug.Log("Player has left");
    }
}
