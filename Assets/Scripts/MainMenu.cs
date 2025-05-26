using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    /// <summary>
    /// Material de las trampas (Trap).
    /// </summary>
    public Material trapMat;

    /// <summary>
    /// Material del objetivo (Goal).
    /// </summary>
    public Material goalMat;

    /// <summary>
    /// Toggle para modo daltonismo.
    /// </summary>
    public Toggle colorblindMode;

    /// <summary>
    /// Inicializa estado de los menús.
    /// </summary>
    void Start()
    {
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
    /// Ajusta colores si el modo colorblind está activado.
    /// </summary>
    public void PlayMaze()
    {
        if (colorblindMode != null && trapMat != null && goalMat != null)
        {
            if (colorblindMode.isOn)
            {
                trapMat.color = new Color32(255, 112, 0, 255); // 🟧 naranja
                goalMat.color = Color.blue;                   // 🔵 azul
            }
            else
            {
                trapMat.color = Color.red;     // 🔴 color original
                goalMat.color = Color.green;   // 🟢 color original
            }
        }

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
