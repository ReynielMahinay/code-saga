using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockBack : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2;

    [SerializeField]
    private float streangth = 10, delay = 0.10f;

    public UnityEvent onBegin, onDone;

    public void PlayKnockBack(GameObject sender){

        StopAllCoroutines();
        onBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb2.AddForce(direction * streangth, ForceMode2D.Impulse);
        StartCoroutine(Reset());

    }

    private IEnumerator  Reset(){

        yield return new WaitForSeconds(delay);
        rb2.velocity = Vector3.zero;
        onDone?.Invoke();
    
    }
}
