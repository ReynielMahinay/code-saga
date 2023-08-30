using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerToSkip : MonoBehaviour
{
    public GameObject skip;
    [SerializeField]
    private int delay = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(skipVid());
    }

    private IEnumerator skipVid(){
        yield return new WaitForSeconds(delay);
        skip.SetActive(true);
    }
}
