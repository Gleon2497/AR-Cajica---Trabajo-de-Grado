using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// La clase <c>GameManager</c> gestiona los eventos del men� principal, men� de �tems y men� de posici�n AR.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Evento que se dispara cuando se activa el men� principal.
    /// </summary>
    public event Action OnMainMenu;

    /// <summary>
    /// Evento que se dispara cuando se activa el men� de �tems.
    /// </summary>
    public event Action OnItemsMenu;

    /// <summary>
    /// Evento que se dispara cuando se activa el men� de posici�n AR.
    /// </summary>
    public event Action OnARPosition;

    /// <summary>
    /// Instancia est�tica de la clase <c>GameManager</c>.
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// El m�todo <c>Awake</c> asegura que solo haya una instancia de <c>GameManager</c>.
    /// </summary>
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    /// <summary>
    /// El m�todo <c>Start</c> activa el men� principal al iniciar.
    /// </summary>
    void Start()
    {
        MainMenu();
    }

    /// <summary>
    /// El m�todo <c>MainMenu</c> invoca el evento <c>OnMainMenu</c> y muestra un mensaje de depuraci�n.
    /// </summary>
    public void MainMenu()
    {
        OnMainMenu?.Invoke();
        Debug.Log("Main Menu Activated");
    }

    /// <summary>
    /// El m�todo <c>ItemsMenu</c> invoca el evento <c>OnItemsMenu</c> y muestra un mensaje de depuraci�n.
    /// </summary>
    public void ItemsMenu()
    {
        OnItemsMenu?.Invoke();
        Debug.Log("Items Menu Activated");
    }

    /// <summary>
    /// El m�todo <c>ARPosition</c> invoca el evento <c>OnARPosition</c> y muestra un mensaje de depuraci�n.
    /// </summary>
    public void ARPosition()
    {
        OnARPosition?.Invoke();
        Debug.Log("AR Position Activated");
    }

    /// <summary>
    /// El m�todo <c>CloseApp</c> cierra la aplicaci�n.
    /// </summary>
    public void CloseApp()
    {
        Application.Quit();
    }
}
