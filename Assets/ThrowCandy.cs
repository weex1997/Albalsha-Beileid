using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ThrowCandy : MonoBehaviour
{
    public Animator animatorPlayer;
    public Animator animatorOldMan;
    bool startGame = true;
    public GameObject sofaPosthin;
    int OldManAwake;
    GameObject TimerObject;
    public bool stopWin = false;

    void Start()
    {
        TimerObject = GameObject.FindWithTag("Timer");
        GameManager.Instance.TimerImage = TimerObject.GetComponent<Image>();
        GameManager.Instance.MaxTime = 6;
    }
    void RandomAnim()
    {
        OldManAwake = Random.Range(0, 3);
        Debug.Log(OldManAwake);
    }

    // Update is called once per frame
    void Update()
    {
        while (startGame)
        {
            startGame = false;
            RandomAnim();
            if (OldManAwake >= 2)
            {
                animatorOldMan.SetBool("sleep", false);
            }
            else
            {
                animatorOldMan.SetBool("sleep", true);
            }
            StartCoroutine(Wite());
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            //start throw
            animatorPlayer.SetBool("Run", true);
            transform.DOJump(sofaPosthin.transform.position, 2, 1, 2);
            Debug.Log(animatorOldMan.GetCurrentAnimatorClipInfo(0)[0].clip.name);

            if (animatorOldMan.GetCurrentAnimatorClipInfo(0)[0].clip.name == "idel")
            {
                animatorOldMan.SetBool("lose", true);
                StartCoroutine(WaitAnim());
            }
        }
        if (GameManager.Instance.TimerImage.fillAmount <= 0)
        {
            GameManager.Instance.Lose(0);
        }

    }
    IEnumerator Wite()
    {
        while (!startGame)
        {

            yield return new WaitForSeconds(2f);
            if (OldManAwake >= 2)
            {
                animatorOldMan.SetBool("sleep", true);
            }
            else
            {
                animatorOldMan.SetBool("sleep", false);
            }
            yield return new WaitForSeconds(2f);
            startGame = true;
        }

    }
    IEnumerator WaitAnim()
    {
        stopWin = true;
        yield return new WaitForSeconds(1f);
        GameManager.Instance.Lose(0);
    }
}
