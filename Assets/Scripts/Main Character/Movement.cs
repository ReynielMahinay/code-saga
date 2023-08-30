using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Movement : MonoBehaviour,  IDataPersistent
{   
    public AudioSource steps;

    private Rigidbody2D rb;
    [SerializeField]
    private float maxSpeed = 5, acceleration = 50, deacceleration = 100;
    [SerializeField]
    private float currentSpeed = 0;
    private Vector2 oldMovementInput;
    public Vector2 MovementInput { get; set; }
    
    
    private void Start() {
    }

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (MovementInput.magnitude > 0 && currentSpeed >= 0)
        {
            oldMovementInput = MovementInput;
            currentSpeed += acceleration * maxSpeed * Time.deltaTime;
            steps.enabled = true;
        }
        else
        {
            currentSpeed -= deacceleration * maxSpeed * Time.deltaTime;
            steps.enabled = false;

        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        rb.velocity = oldMovementInput * currentSpeed;

    }
    public void LoadData(GameData data){
        this.transform.position = data.playerPosition;
    }

    public void SaveData(GameData data)
    {
    data.playerPosition = this.transform.position;
    }

}
