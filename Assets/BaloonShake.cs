using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class BaloonShake : MonoBehaviour
{
    float duration = 5;
    bool startCoroutin = false;
    bool startCorotinAnim = false;
    Sprite Moneysprite;
    // Start is called before the first frame update
    void Start()
    {
        startCoroutin = true;
        StartCoroutine(Wite());
    }

    IEnumerator Wite()
    {
        while (startCoroutin)
        {
            startCoroutin = false;
            transform.DOShakePosition(duration, 0.07f, 1, 90);
            yield return new WaitForSeconds(2);
            startCoroutin = true;
            StartCoroutine(Wite());
        }

    }

    public void changeSprite(Sprite sprite)
    {
        Moneysprite = sprite;
        startCorotinAnim = true;
        StartCoroutine(Animation());
    }
    IEnumerator Animation()
    {
        while (startCorotinAnim)
        {
            startCorotinAnim = false;
            yield return new WaitForSeconds(0.1f);



        }

    }
}
