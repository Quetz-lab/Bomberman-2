using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    //CharacterController characterController;
    InputSystem_Actions actions;
    public Vector2 moveDir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    actions = new InputSystem_Actions();
    //characterController = GetComponent<CharacterController>();
        actions.Enable();
        actions.Player.Move.performed += i => moveDir = i.ReadValue<Vector2>();
        actions.Player.Move.canceled += i => moveDir = Vector2.zero;

       
        
    }

    // Update is called once per frame
    void Update()
    {
        //characterController.Move(new Vector3(moveDir.x, 0, moveDir.y) * Time.deltaTime);
    }

}
