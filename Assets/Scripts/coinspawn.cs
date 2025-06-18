using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinspawn : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform[] pos;
    //int wait = 50;
    void Start()
    {
        StartCoroutine(coinSpawn());
    }

    IEnumerator coinSpawn()
    {
        while (true) { 
            yield return new WaitForSeconds(0.5f);
            Instantiate(coinPrefab, pos[Random.Range(0, 3)].position, Quaternion.identity);
        }
    }

    void Update()
    {
        //if(wait == 0)
        //{
        //    Instantiate(coinPrefab, pos[Random.Range(0,3)].position, Quaternion.identity);
        //    wait = 50;
        //}
        //else
        //{
        //    wait--;
        //}
    }
}
