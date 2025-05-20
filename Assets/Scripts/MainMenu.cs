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
    /// </summary>
    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit(); // Solo funciona en compilaciones, no en el editor
    }
}
