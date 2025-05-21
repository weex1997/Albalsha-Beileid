using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStress : MonoBehaviour
{
    public Image cooldown;
    public float waitTime;
    public Animator guest;
    public Animator player;
    public Image guestText;
    GameObject TimerObject;
    bool stopWin = false;

    void Start()
    {
        TimerObject = GameObject.FindWithTag("Timer");
        GameManager.Instance.TimerImage = TimerObject.GetComponent<Image>();
        GameManager.Instance.MaxTime = 6;
    }
    // Update is called once per frame
    void Update()
    {

        cooldown.fillAmount += 1.2f / waitTime * Time.deltaTime;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            //start throw
            cooldown.fillAmount -= 0.03f;
        }

        //lose
        if (cooldown.fillAmount == 1)
        {
            cooldown.enabled = false;
            guestText.enabled = false;
            guest.SetBool("angry", true);
            player.SetBool("angry", true);
            StartCoroutine(WaitAnim());
        }

        //win
        if (GameManager.Instance.TimerImage.fillAmount <= 0 && !stopWin)
        {
            GameManager.Instance.Win(3);
        }
    }
    IEnumerator WaitAnim()
    {
        stopWin = true;
        yield return new WaitForSeconds(1f);
        GameManager.Instance.Lose(3);
    }
}
