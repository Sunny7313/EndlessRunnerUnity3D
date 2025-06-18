using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class side2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0f;
    float acceleration = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed += acceleration * Time.deltaTime;
        StartCoroutine("roadWait");
    }
    IEnumerator roadWait()
    {
        yield return new WaitForSeconds(0.96f);
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        if (transform.position.z < -50)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 100);
        }
    }
}
