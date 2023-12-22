using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacterHandler : MonoBehaviour
{
    [SerializeField] private bool isEnemy = false;
    [SerializeField] private float moveSpeed = 3f;

    private void Update()
    {
        transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        if (isEnemy)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            GameHandler.gameScore++;
            Destroy(gameObject,2.5f);
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            GameHandler.gameScore++;
            Destroy(gameObject, 2.5f);
            GameHandler.gameOver = true;
        }
    }
}
