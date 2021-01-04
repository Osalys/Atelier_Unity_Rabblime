using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountDown : MonoBehaviour
{

    [SerializeField] int startCountDown = 30;
    [SerializeField] Text TxtCountDown;

    // Start is called before the first frame update
    void Start()
    {
        TxtCountDown.text = "TimeLeft : " + startCountDown;
        StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        while (startCountDown > 0)
        {
            yield return new WaitForSeconds(1f);
            startCountDown--;
            TxtCountDown.text = "TimeLeft : " + startCountDown;
        }

        Debug.Log("You are Dead !");
        
    }
   
}
