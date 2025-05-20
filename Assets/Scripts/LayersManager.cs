using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class LayersManager : MonoBehaviour
{
    //PlayerManagerxd
    PlayerInputManager playerInputManager;
    [SerializeField] List<Transform> spawnPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        
    }

    public void OnPlayerJoin(PlayerInput player)
    {
        Debug.Log("Player has Joined");
        player.gameObject.transform.position = spawnPos[playerInputManager.playerCount - 1].position;
    }
    public void OnPlayerLeft(PlayerInput player)
    {
        Debug.Log("Player has left");
    }
}
