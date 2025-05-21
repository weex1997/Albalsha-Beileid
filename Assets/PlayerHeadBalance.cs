using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadBalance : MonoBehaviour
{
    public Balance balance;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
            StartCoroutine(WaitAnim());
    }
    IEnumerator WaitAnim()
    {
        balance.stopWin = true;
        yield return new WaitForSeconds(1f);
        GameManager.Instance.Lose(1);
    }
}
