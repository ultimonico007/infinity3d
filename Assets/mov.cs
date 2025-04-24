using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mov : MonoBehaviour
{
    private int currentLane = 1;
    public float laneDistance = 2f;
    public float moveSpeed = 5f;
    public bool isDead = false;

    public GameObject restartUI;

    void Start()
    {
        restartUI.SetActive(false);
        Time.timeScale = 1f; // Por si reiniciás y estaba pausado
    }

    void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane > 0)
            currentLane--;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane < 2)
            currentLane++;

        Vector3 targetPos = transform.position;
        targetPos.x = (currentLane - 1) * laneDistance;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisión con: " + other.gameObject.name + " / Tag: " + other.tag);
        if ((other.CompareTag("red") || other.CompareTag("yellow") || other.CompareTag("green")) && transform.position.y < 1f)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        restartUI.SetActive(true);
        Time.timeScale = 0f; // Pausa el juego
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Restaura velocidad normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}