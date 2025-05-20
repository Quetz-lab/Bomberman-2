using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

public class InputManager : MonoBehaviour
{
    
    //CharacterController characterController;
    InputSystem_Actions actions;
    public Vector2 moveDir;
    [HideInInspector]public UnityEvent OnBombPressed;
  
   

    public void OnAttack(CallbackContext context)
    {
        if (context.performed) OnBombPressed?.Invoke();
    }

    public void OnMove(CallbackContext context)
    {
        if (context.performed)moveDir = context.ReadValue<Vector2>();
        else if (context.canceled) moveDir = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //characterController.Move(new Vector3(moveDir.x, 0, moveDir.y) * Time.deltaTime);
    }

}
