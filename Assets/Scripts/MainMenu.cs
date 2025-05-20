using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controlador del menú principal. Gestiona el botón Play.
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
}
