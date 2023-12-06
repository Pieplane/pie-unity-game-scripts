using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBarrier : MonoBehaviour
{
    public float respawnTime = 1.0f;
    public GameObject[] barrier;

    float xMax, yMin, yMax;
    public bool needSpawn;
    public bool needRandom = false;
    int randomNumber;

    private void Start()
    {
        needSpawn = true;
        StartCoroutine(BarrierWave());
    }
    private void Update()
    {
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }
    void CreateBarrier(bool needSpawn)
    {
        if (needSpawn)
        {
            if (needRandom)
            {
                randomNumber = Random.Range(0, 2);
                GameObject newBarrier = Instantiate(barrier[randomNumber]) as GameObject;
                newBarrier.transform.position = new Vector2(xMax + 1, Random.Range(yMax - 1, yMin + 1));
            }
            else
            {
                GameObject newBarrier = Instantiate(barrier[0]) as GameObject;
                newBarrier.transform.position = new Vector2(xMax + 1, Random.Range(yMax - 1, yMin + 1));
            } 
        }
        else
            return;
    }
    IEnumerator BarrierWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            CreateBarrier(needSpawn);
        }
    }
}
