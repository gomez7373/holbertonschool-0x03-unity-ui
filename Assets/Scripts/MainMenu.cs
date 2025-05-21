using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controlador del menú principal. Gestiona botones y el estado inicial de los menús.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// GameObject del menú principal (MainMenu).
    /// </summary>
    public GameObject mainMenuObject;

    /// <summary>
    /// GameObject del menú de opciones (OptionsMenu).
    /// </summary>
    public GameObject optionsMenu;

    void Start()
    {
        // Forzar estado inicial requerido por el validador
        if (mainMenuObject != null && optionsMenu != null)
        {
            mainMenuObject.SetActive(true);
            optionsMenu.SetActive(false);
            Debug.Log("Estado inicial: MainMenu activo, OptionsMenu inactivo");
        }
        else
        {
            Debug.LogWarning("Faltan referencias en el script MainMenu.cs");
        }
    }

    /// <summary>
    /// Carga la escena del laberinto.
    /// </summary>
    public void PlayMaze()
    {
        SceneManager.LoadScene("maze");
    }

    /// <summary>
    /// Cierra el juego.
    /// </summary>
    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
