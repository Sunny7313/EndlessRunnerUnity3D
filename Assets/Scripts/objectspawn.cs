using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectspawn : MonoBehaviour
{
    public GameObject[] EObjects;
    public Transform[] pos;
    void Start()
    {
        StartCoroutine(spawn());

    }

    IEnumerator spawn()
    {
        while (true) { 
            yield return new WaitForSeconds(1f);
            Vector3 chpos = pos[Random.Range(0, pos.Length)].position;
            GameObject chobject = EObjects[Random.Range(0, EObjects.Length)];
            Instantiate(chobject, chpos, transform.rotation);
        }
    }

}
