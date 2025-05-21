using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Balance : MonoBehaviour
{
    Rigidbody2D rigidbody;
    int dirction;
    Vector3 dirctionVictor;
    GameObject TimerObject;
    public bool stopWin = false;

    void Start()
    {
        TimerObject = GameObject.FindWithTag("Timer");
        GameManager.Instance.TimerImage = TimerObject.GetComponent<Image>();
        GameManager.Instance.MaxTime = 6;

        dirction = Random.Range(0, 1);
        if (dirction == 0)
            dirctionVictor = Vector3.left;
        else
            dirctionVictor = Vector3.right;

        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(dirctionVictor * 10);

    }
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

            if (hit)
            {
                if (hit.collider.tag == "right")
                {
                    rigidbody.AddForce(Vector3.right * 50);
                    Debug.Log("Hit!");
                }

                if (hit.collider.tag == "left")
                {
                    rigidbody.AddForce(Vector3.left * 50);
                    Debug.Log("Hit!");
                }
            }
        }
        if (GameManager.Instance.TimerImage.fillAmount <= 0 && !stopWin)
        {
            GameManager.Instance.Win(1);
        }
    }
}
