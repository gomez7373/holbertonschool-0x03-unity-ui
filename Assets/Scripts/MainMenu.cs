using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controlador del menú principal. Gestiona los botones del menú principal.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Carga la escena del laberinto cuando se presiona Play.
    /// </summary>
    public void PlayMaze()
    {
        SceneManager.LoadScene("maze");
    }

    /// <summary>
    /// Cierra el juego cuando se presiona el botón Quit.
    /// Muestra un mensaje en la consola si se ejecuta dentro del editor.
    /// </summaryusing UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controlador del menú principal. Gestiona los botones del menú principal y el estado inicial de los menús.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Referencia al menú principal (MainMenu GameObject).
    /// </summary>
    public GameObject mainMenu;

    /// <summary>
    /// Referencia al menú de opciones (OptionsMenu GameObject).
    /// </summary>
    public GameObject optionsMenu;

    /// <summary>
    /// Al iniciar la escena, se asegura que solo MainMenu esté activo.
    /// </summary>
    void Start()
    {
        if (mainMenu != null)
            mainMenu.SetActive(true);

        if (optionsMenu != null)
            optionsMenu.SetActive(false);
    }

    /// <summary>
    /// Carga la escena del laberinto cuando se presiona Play.
    /// </summary>
    public void PlayMaze()
    {
        SceneManager.LoadScene("maze");
    }

    /// <summary>
    /// Cierra el juego cuando se presiona el botón Quit.
    /// Muestra un mensaje en la consola si se ejecuta dentro del editor.
    /// </summary>
    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit(); // Solo funciona en compilaciones, no en el editor
    }
}

public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit(); // Solo funciona en compilaciones, no en el editor
    }
}
