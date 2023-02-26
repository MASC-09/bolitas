using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    private int enemyCount = 0;
    [SerializeField] private Text counterText;
    private string SceneName = "EndGame";
    [SerializeField] private string UI_TEXT = "Chanchos Locos";
    // [SerializeField] private int waitTime = 3;

    void Start()
    {
        counterText = GetComponent<Text>();
        UpdateCounterText();
    }

    void Update()
    {
        if (enemyCount >= 10)
        {   
            // StartCoroutine(AddWaitTime());
            SceneManager.LoadScene(SceneName);
        }
    }

    public void AddEnemy()
    {
        if (enemyCount < 10)
        {
            enemyCount ++;
            UpdateCounterText();
        }
    }
    
    private void UpdateCounterText()
    {
        if (counterText != null)
        {
            counterText.text = UI_TEXT + ": "+ enemyCount.ToString();
        }
    }

    // IEnumerator AddWaitTime()
    // {
    //     yield return new WaitForSeconds(waitTime);
    // }
}
