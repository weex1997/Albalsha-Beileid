using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaloonGameController : MonoBehaviour
{
    public List<int> points = new List<int>();
    public List<Sprite> Sprites = new List<Sprite>();
    public Sprite sprite;

    public int Point;
    int rand;
    public TMP_Text pointText;
    public TMP_Text pointTextEffict;
    public GameObject pointTextEffictBase;
    bool startCoroutin = false;
    GameObject TimerObject;
    public AudioClip baloon;


    // Start is called before the first frame update
    void Start()
    {
        TimerObject = GameObject.FindWithTag("Timer");
        GameManager.Instance.TimerImage = TimerObject.GetComponent<Image>();
        GameManager.Instance.MaxTime = 3;

        points.Add(100);
        points.Add(5);
        points.Add(1);
        points.Add(500);
        points.Add(10);
        points.Add(200);
        points.Add(2);
        points.Add(20);
        points.Add(50);
        points.Add(200);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

            if (hit)
            {
                if (hit.collider.tag == "Baloon")
                {
                    SoundManager.Instance.RandomSoundEffect(baloon);
                    rand = Random.Range(0, points.Count);
                    Point += points[rand];
                    pointText.text = Point.ToString();

                    for (int i = 0; i < Sprites.Count; i++)
                    {
                        if (Sprites[i].name == points[rand].ToString())
                        {
                            sprite = Sprites[i];
                            break; //don't need to check the remaining ones now that we found one
                        }
                    }
                    hit.collider.gameObject.GetComponent<Animator>().SetBool("boom", true);
                    hit.collider.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprite;
                    hit.collider.gameObject.gameObject.GetComponent<Collider2D>().enabled = false;

                    startCoroutin = true;
                    StartCoroutine(PointsEffict());

                    points.RemoveAt(rand);
                }
            }
        }
        if (GameManager.Instance.TimerImage.fillAmount <= 0)
        {
            if (Point >= 500)
            {
                GameManager.Instance.Win(2);
            }
            else
                StartCoroutine(WaitAnim());
        }
    }
    IEnumerator WaitAnim()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.Lose(2);
    }
    IEnumerator PointsEffict()
    {
        while (startCoroutin)
        {
            yield return new WaitForSeconds(0.4f);
        }
    }

}
