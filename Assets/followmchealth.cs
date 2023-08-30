using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followmchealth : MonoBehaviour
{
    [SerializeField] private GameObject mc;
     [SerializeField] private float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,mc.transform.position, speed * Time.deltaTime);
        transform.up = mc.transform.position - transform.position;
    }
}
