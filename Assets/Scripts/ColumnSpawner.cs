using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnSpawner : MonoBehaviour
{
    public GameObject columnPrefab;

    public float minY, maxY;

    float timer;
    public float maxTime;

    float timerToSpeedUp;
    public float timeToSpeedUp;

    void Update()
    {
        //spawn columns every x amount of seconds
        timer += Time.deltaTime;
        timerToSpeedUp += Time.deltaTime;
        if (timer >= maxTime)
        {
            SpawnColumn();
            timer = 0f;
        }

        if (timerToSpeedUp >= timeToSpeedUp)
        {
            maxTime = maxTime - 0.5f;
            timerToSpeedUp = 0f;
        }

        void SpawnColumn()
        {
            float randYPos = Random.Range(minY, maxY);

            GameObject newColumn = Instantiate(columnPrefab);
            newColumn.transform.position = new Vector2(transform.position.x, randYPos);
        }
    }
}
