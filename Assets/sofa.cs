using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sofa : MonoBehaviour
{
    public ThrowCandy throwCandy;
    public Animator animatorOldMan;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Candy")
        {
            if (animatorOldMan.GetCurrentAnimatorClipInfo(0)[0].clip.name == "idel")
            {
                animatorOldMan.SetBool("lose", true);
                StartCoroutine(WaitAnim());

            }
            else if (!throwCandy.stopWin)
            {
                animatorOldMan.SetBool("win", true);
                GameManager.Instance.Win(0);
            }

        }


    }
    IEnumerator WaitAnim()
    {
        throwCandy.stopWin = true;
        yield return new WaitForSeconds(1f);
        GameManager.Instance.Lose(0);
    }
}
