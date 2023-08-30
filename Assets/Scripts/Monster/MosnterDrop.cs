using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosnterDrop : MonoBehaviour
{

    public Transform Target;
    public float MinModifier = 5;
    public float MaxModifier = 10;

    Vector3 _velocity = Vector3.zero;

    bool isFollowing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartFollowing(){
        isFollowing = true;
    }
    // Update is called once per frame
    void Update()
    {   
        if(isFollowing){
        transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref _velocity, Time.deltaTime * Random.Range(MinModifier, MaxModifier));
        }
    }   
}
