using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : MonoBehaviour
{
    bool isOnGround;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //camera.transform.position = new Vector3(transform.position.x, 0, 0);
        transform.Translate(Vector2.right * 4 * Time.deltaTime);
        if (Input.GetMouseButtonDown(0) && isOnGround) jump();
    }
    void jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400.0f));
        isOnGround = false;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.gameObject.tag == "ground") isOnGround = true;
        else isOnGround = false;
    }
}
