using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Controlador principal del jugador. Maneja movimiento, puntuación, salud,
/// interacciones con objetos (trampas, pickups, teleporters y meta),
/// y actualización de la interfaz de usuario.
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Velocidad del jugador.
    /// </summary>
    public float speed = 5f;

    /// <summary>
    /// Vida del jugador.
    /// </summary>
    public int health = 5;

    /// <summary>
    /// Texto en la UI que muestra el puntaje.
    /// </summary>
    public Text scoreText;

    /// <summary>
    /// Texto en la UI que muestra la salud.
    /// </summary>
    public Text healthText;

    private int score = 0;
    private Rigidbody rb;
    private float teleportCooldown = 0f;

    /// <summary>
    /// Inicializa componentes y muestra los valores iniciales en pantalla.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetScoreText();
        SetHealthText();
    }

    /// <summary>
    /// Controla el movimiento del jugador usando input horizontal y vertical.
    /// </summary>
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    /// <summary>
    /// Reinicia la escena si la salud del jugador llega a cero.
    /// </summary>
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    /// <summary>
    /// Gestiona colisiones con pickups, trampas, teleporters y meta.
    /// </summary>
    /// <param name="other">El collider con el que el jugador entra en contacto.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            SetHealthText(); // ✅ Actualiza la UI con la nueva salud
            // Debug.Log("Health: " + health); // ❌ Línea eliminada como indica el task
        }

        if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }

        if (other.CompareTag("Teleporter"))
        {
            if (Time.time < teleportCooldown)
                return;

            GameObject[] teleporters = GameObject.FindGameObjectsWithTag("Teleporter");

            foreach (GameObject tp in teleporters)
            {
                if (tp.transform != other.transform)
                {
                    transform.position = tp.transform.position + new Vector3(0, 1, 0);
                    Debug.Log("Teleported!");
                    teleportCooldown = Time.time + 1f;
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Actualiza el texto de puntaje en la UI.
    /// </summary>
    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    /// <summary>
    /// Actualiza el texto de salud en la UI.
    /// </summary>
    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }
}
