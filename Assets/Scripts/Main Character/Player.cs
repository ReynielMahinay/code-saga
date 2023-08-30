using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{   
    private Movement agentMover;
    private WeaponPointer weaponPointer;
    private WeaponPointer2 weaponPointer2;
    private PlayAnimtion playerAnimation;
    private Vector2 pointerInput, movementInput, pointerInput2;
    
    [SerializeField]
    private InputActionReference movement, attack, attack2, pointerPosition;
    

    private void OnEnable()
    {
        attack.action.performed += PerformAttack;
        attack2.action.performed += PerformAttack2;
    }

    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
        attack2.action.performed -= PerformAttack2;
    }

    private void PerformAttack(InputAction.CallbackContext obj)
    {    if(!PauseMenu.isPaused && !Qmaster.onDialog && !GateKeeper.onDialog  && !QNpc.onDialog && !QuestGiver.onDialog && 
        !QuestGiverMB.onDialog&& !QuestGiverLN.onDialog && !Ruin2Quest.onDialog&& !Desert1Quest1.onDialog && 
        !Castle1Quest1.onDialog && !Castle1Quest2.onDialog && !Castle1Quest3.onDialog){
         weaponPointer.Attack();
        }
        
    }

    private void PerformAttack2(InputAction.CallbackContext obj)
    {    if(!PauseMenu.isPaused && !Qmaster.onDialog && !GateKeeper.onDialog  && !QNpc.onDialog && !QuestGiver.onDialog && 
        !QuestGiverMB.onDialog&& !QuestGiverLN.onDialog && !Ruin2Quest.onDialog&& !Desert1Quest1.onDialog && 
        !Castle1Quest1.onDialog && !Castle1Quest2.onDialog && !Castle1Quest3.onDialog){
         weaponPointer2.Attack();
        }
        
    }

    
    private void Awake()
    {   
        weaponPointer = GetComponentInChildren<WeaponPointer>();
        weaponPointer2 = GetComponentInChildren<WeaponPointer2>();
        agentMover = GetComponentInChildren<Movement>();
        playerAnimation = GetComponentInChildren<PlayAnimtion>();

    }

    
    private void AnimateCharacter()
    {
        Vector2 lookDirection = pointerInput - (Vector2)transform.position;
        Vector2 lookDirection2 = pointerInput2 - (Vector2)transform.position;
        playerAnimation.RotateToPointer(lookDirection);
        playerAnimation.RotateToPointer(lookDirection2);
        playerAnimation.PlayAnimation(movementInput);
    }

    void Update()
    {   
        if(!PauseMenu.isPaused && !Qmaster.onDialog && !GateKeeper.onDialog && !QNpc.onDialog && !QuestGiver.onDialog&& !QuestGiverMB.onDialog&& !QuestGiverLN.onDialog && !Ruin2Quest.onDialog&& !Desert1Quest1.onDialog && !Castle1Quest1.onDialog && !Castle1Quest2.onDialog && !Castle1Quest3.onDialog){
        pointerInput = GetPointerInput();
        pointerInput2 = GetPointerInput();
        weaponPointer.PointerPosition = pointerInput;
        weaponPointer2.PointerPosition2 = pointerInput2;
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
