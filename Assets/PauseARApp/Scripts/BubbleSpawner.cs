using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;
    public GameObject donePopupPanel;
    public float spawnInterval = 2f; // time between spawns
    public Vector3 spawnAreaSize = new Vector3(10, 10, 10); // size of bubble spawn area

    public TMP_Text timerText;
    public float gameDuration = 180f;

    public float currentTime = 0f;

    public TMP_Text countdownText;
    public float coundownDuration = 3f;

    private bool isCountdownComplete = false;
    private Coroutine spawnCoroutine;
    private Coroutine countdownCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        StartActivity();
    }

    public void StartActivity()
    {
        currentTime = 0f;
        isCountdownComplete = false;
        donePopupPanel.SetActive(false);
        countdownCoroutine = StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        float countdownTime = coundownDuration;

        while (countdownTime > 0)
        {
            countdownText.text = Mathf.Ceil(countdownTime).ToString();
            yield return new WaitForSeconds(1); // wait for one second
            countdownTime--;
        }

        // clear UI 
        countdownText.text = "";
        isCountdownComplete = true;

        // after countdown, start bubble spawning
        spawnCoroutine = StartCoroutine(SpawnBubbles());
    }

    IEnumerator SpawnBubbles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            Vector3 spawnPosition = transform.position + new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2));
            
            Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCountdownComplete)
        {
            return; // don't start timer if countdown is not complete
        }

        currentTime += Time.deltaTime;

        // calculate remaining time
        float remainingTime = Mathf.Max(gameDuration - currentTime, 0);

        // convert to minutes and seconds
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        // timer display as MM:SS
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // stop when timer ends
        if (currentTime >= gameDuration)
        {
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
            }

            // end popup
            donePopupPanel.SetActive(true);
        }   
    }

    public void ResetActivity()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            spawnCoroutine = null;
        }

        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }

        StopAllCoroutines();

        foreach (GameObject bubble in GameObject.FindGameObjectsWithTag("Bubble"))
        {
            Destroy(bubble);
        }

        StartActivity();
    }
}
