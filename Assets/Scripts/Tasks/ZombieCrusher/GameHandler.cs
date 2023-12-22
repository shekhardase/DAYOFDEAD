using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private float spawnTime = 6f;
    [SerializeField] private Text scoreTxt;

    [SerializeField] private GameObject[] characterPrefab;
    [SerializeField] private GameObject gameOverbtn;

    internal static int gameScore = 0;
    internal static bool gameOver = false;
    private float tempTimer;
    // Start is called before the first frame update
    void Start()
    {
        gameScore = 0;
        gameOver = false;
        tempTimer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            scoreTxt.text = gameScore.ToString();

            if (spawnTime <= 0)
            {
                Instantiate(characterPrefab[Random.Range(0, 2)], spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);
                spawnTime = tempTimer;
            }
            else
            {
                spawnTime -= Time.deltaTime;
            }
        }
        else
        {
            gameOverbtn.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Ground")
        {
            Destroy(other.gameObject);
        }
    }

    public void RetryBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
