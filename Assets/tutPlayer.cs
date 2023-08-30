using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class tutPlayer : MonoBehaviour
{
   private Movement agentMover;
    private WeaponPointer weaponPointer;
    
    private PlayAnimtion playerAnimation;
    private Vector2 pointerInput, movementInput, pointerInput2;
    
    [SerializeField]
    private InputActionReference movement, attack, pointerPosition;
    

    private void OnEnable()
    {
        attack.action.performed += PerformAttack;
        
    }

    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
        
    }

    private void PerformAttack(InputAction.CallbackContext obj)
    {    if(!PauseMenu.isPaused && !Qmaster.onDialog && !GateKeeper.onDialog){
         weaponPointer.Attack();
        }
        
    }

   

    
    private void Awake()
    {   
        weaponPointer = GetComponentInChildren<WeaponPointer>();
        
        agentMover = GetComponentInChildren<Movement>();
        playerAnimation = GetComponentInChildren<PlayAnimtion>();

    }

    
    private void AnimateCharacter()
    {
        Vector2 lookDirection = pointerInput - (Vector2)transform.position;
       
        playerAnimation.RotateToPointer(lookDirection);
       
        playerAnimation.PlayAnimation(movementInput);
    }

    void Update()
    {   
        if(!PauseMenu.isPaused && !Qmaster.onDialog && !GateKeeper.onDialog){
        pointerInput = GetPointerInput();
        pointerInput2 = GetPointerInput();
        weaponPointer.PointerPosition = pointerInput;
        
        movementInput = movement.action.ReadValue<Vector2>().normalized;
        agentMover.MovementInput = movementInput;
        }
        AnimateCharacter();

    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
