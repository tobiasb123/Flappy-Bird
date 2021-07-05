using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountdownController : MonoBehaviour
{
    [SerializeField] private int countdownTime;
    [SerializeField] private Text countdownDisplay;

    public GameObject columns;

    public GameObject Barrier;

    private void Awake()
    {
        columns.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay.text = "GO!";

        yield return new WaitForSeconds(1f);

        Timer.instance.BeginTimer();

        countdownDisplay.gameObject.SetActive(false);

        Barrier.SetActive(false);

        columns.SetActive(true);
    }
}
