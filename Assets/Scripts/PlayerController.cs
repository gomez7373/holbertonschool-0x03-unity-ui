using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;           // Velocidad del jugador
    public int health = 5;             // Vida del jugador

    private int score = 0;             // Puntaje inicial
    private Rigidbody rb;              // Referencia al Rigidbody
    private float teleportCooldown = 0f; // Tiempo de espera entre teletransportes

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener Rigidbody del jugador
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void Update()
    {
        // Reiniciar si la vida llega a cero
        if (health <= 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Recolectar objetos
        if (other.CompareTag("Pickup"))
        {
            score++;
            Debug.Log("Score: " + score);
            other.gameObject.SetActive(false);
        }

        // Recibir daño
        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health);
        }

        // Ganar el juego
        if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }

        // Teletransportarse
        if (other.CompareTag("Teleporter"))
        {
            // Evitar múltiples teletransportes seguidos
            if (Time.time < teleportCooldown)
                return;

            GameObject[] teleporters = GameObject.FindGameObjectsWithTag("Teleporter");

            foreach (GameObject tp in teleporters)
            {
                if (tp.transform != other.transform)
                {
                    transform.position = tp.transform.position + new Vector3(0, 1, 0); // Teleport con ajuste vertical
                    Debug.Log("Teleported!");
                    teleportCooldown = Time.time + 1f; // 1 segundo de cooldown
                    break;
                }
            }
        }
    }
}
