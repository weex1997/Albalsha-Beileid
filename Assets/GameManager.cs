using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<int> GamesNumbers;
    public AudioClip music;

    public float MaxTime;

    public Image TimerImage;
    public int loseImageName;
    public int winImageName;
    public List<int> scenes;
    public bool lose = false;
    public bool win = false;
    bool startTimer = false;
    bool stopEnd = false;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        SoundManager.Instance.PlayMusic(music);
    }
    // Update is called once per frame
    void Update()
    {
        if (TimerImage != null && startTimer)
        {
            TimerImage.fillAmount -= 1.0f / MaxTime * Time.deltaTime;
        }
        while (scenes.Count == 4 && !stopEnd)
        {
            stopEnd = true;
            SceneManager.UnloadSceneAsync("Win");
            SceneManager.LoadScene("End", LoadSceneMode.Additive);
        }
    }
    public void Win(int name)
    {
        while (!win)
        {
            win = true;
            lose = true;
            SceneManager.LoadScene("Win", LoadSceneMode.Additive);
            winImageName = name;
        }
    }
    public void Lose(int name)
    {
        while (!lose)
        {
            lose = true;
            win = true;
            SceneManager.LoadScene("Lose", LoadSceneMode.Additive);
            loseImageName = name;
            scenes.Clear();
        }

    }

    public void Loadscene(int num)
    {
        StartCoroutine(Wait(num));
    }
    IEnumerator Wait(int num)
    {
        SceneManager.LoadScene("TranstionIn", LoadSceneMode.Additive);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(num);
        SceneManager.UnloadSceneAsync("TranstionIn");
        SceneManager.LoadScene("TranstionOut", LoadSceneMode.Additive);
        yield return new WaitForSeconds(1f);
        SceneManager.UnloadSceneAsync("TranstionOut");
        startTimer = true;
        lose = false;
        win = false;
    }

}
