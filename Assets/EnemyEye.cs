using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyEye : MonoBehaviour
{
    public Image cooldown;
    public int closeEye;
    public float waitTime = 0.3f;
    bool startCoroutine = false;
    private void Start()
    {
        closeEye = Random.Range(0, 1);
    }
    // Update is called once per frame
    void Update()
    {
        if (closeEye == 0)
        {
            //Reduce fill amount over 30 seconds
            cooldown.fillAmount += 1.0f / waitTime * Time.deltaTime;
            Invoke("waitOpen", 2f);
        }
        if (closeEye == 1)
        {
            //Reduce fill amount over 30 seconds
            cooldown.fillAmount -= 1.0f / waitTime * Time.deltaTime;
            Invoke("waitClose", 2f);
        }
    }
    void waitClose()
    {
        closeEye = 0;
    }
    void waitOpen()
    {

        closeEye = 1;
    }
}
