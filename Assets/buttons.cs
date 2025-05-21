using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    [SerializeField] List<GameObject> LoseImages;
    [SerializeField] List<GameObject> WinImages;

    GameObject LoseImage;
    GameObject WinImage;

    int rand;
    void Start()
    {
        if (LoseImages.Count > 1)
        {
            LoseImage = LoseImages[GameManager.Instance.loseImageName];
            LoseImage.SetActive(true);
        }
        if (WinImages.Count > 1)
        {
            WinImage = WinImages[GameManager.Instance.winImageName];
            WinImage.SetActive(true);
        }
    }
    public void Loadscene(int num)
    {
        GameManager.Instance.Loadscene(num);
    }
    public void StartButton()
    {
        rand = Random.Range(1, 5);
        GameManager.Instance.Loadscene(rand);
    }
    public void nextGame()
    {
        rand = Random.Range(1, 5);
        while (GameManager.Instance.scenes.Contains(rand) && GameManager.Instance.scenes.Count < 4)
        {
            rand = Random.Range(1, 5);

        }
        GameManager.Instance.Loadscene(rand);
    }
}
