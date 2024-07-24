using UnityEngine;
using UnityEngine.UI;

public class GesturesGuideController : MonoBehaviour
{
    public GameObject gesturePanel; // Referencia al panel de gestos

    private bool panelVisible = true; // Variable para controlar el estado del panel

    void Start()
    {
        ShowPanel(); // Mostrar el panel al iniciar la app
    }

    void Update()
    {
        // Detectar el toque en la pantalla
        if (Input.GetMouseButtonDown(0))
        {
            // Si el panel está visible, ocultarlo; si no, ignorar el clic
            if (panelVisible)
                HidePanel();
        }
    }

    void ShowPanel()
    {
        gesturePanel.SetActive(true); // Activar el panel de gestos
        panelVisible = true; // Actualizar el estado del panel
    }

    void HidePanel()
    {
        gesturePanel.SetActive(false); // Desactivar el panel de gestos
        panelVisible = false; // Actualizar el estado del panel
    }
}