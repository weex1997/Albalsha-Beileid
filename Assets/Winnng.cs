using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winnng : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.scenes.Add(SceneManager.GetActiveScene().buildIndex);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
