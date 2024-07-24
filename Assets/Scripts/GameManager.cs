using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// La clase <c>GameManager</c> gestiona los eventos del menú principal, menú de ítems y menú de posición AR.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Evento que se dispara cuando se activa el menú principal.
    /// </summary>
    public event Action OnMainMenu;

    /// <summary>
    /// Evento que se dispara cuando se activa el menú de ítems.
    /// </summary>
    public event Action OnItemsMenu;

    /// <summary>
    /// Evento que se dispara cuando se activa el menú de posición AR.
    /// </summary>
    public event Action OnARPosition;

    /// <summary>
    /// Instancia estática de la clase <c>GameManager</c>.
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// El método <c>Awake</c> asegura que solo haya una instancia de <c>GameManager</c>.
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
    /// El método <c>Start</c> activa el menú principal al iniciar.
    /// </summary>
    void Start()
    {
        MainMenu();
    }

    /// <summary>
    /// El método <c>MainMenu</c> invoca el evento <c>OnMainMenu</c> y muestra un mensaje de depuración.
    /// </summary>
    public void MainMenu()
    {
        OnMainMenu?.Invoke();
        Debug.Log("Main Menu Activated");
    }

    /// <summary>
    /// El método <c>ItemsMenu</c> invoca el evento <c>OnItemsMenu</c> y muestra un mensaje de depuración.
    /// </summary>
    public void ItemsMenu()
    {
        OnItemsMenu?.Invoke();
        Debug.Log("Items Menu Activated");
    }

    /// <summary>
    /// El método <c>ARPosition</c> invoca el evento <c>OnARPosition</c> y muestra un mensaje de depuración.
    /// </summary>
    public void ARPosition()
    {
        OnARPosition?.Invoke();
        Debug.Log("AR Position Activated");
    }

    /// <summary>
    /// El método <c>CloseApp</c> cierra la aplicación.
    /// </summary>
    public void CloseApp()
    {
        Application.Quit();
    }
}
