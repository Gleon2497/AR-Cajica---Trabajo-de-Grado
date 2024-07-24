using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

/// <summary>
/// La clase <c>UIManager</c> gestiona las transiciones de la interfaz de usuario entre diferentes menús en la aplicación.
/// </summary>
public class UIManager : MonoBehaviour
{
    /// <summary>
    /// El GameObject del canvas del menú principal.
    /// </summary>
    [SerializeField] private GameObject mainMenuCanvas;

    /// <summary>
    /// El GameObject del canvas del menú de ítems.
    /// </summary>
    [SerializeField] private GameObject itemsMenuCanvas;

    /// <summary>
    /// El GameObject del canvas de la posición AR.
    /// </summary>
    [SerializeField] private GameObject ARPositionCanvas;

    /// <summary>
    /// El método <c>Start</c> suscribe los métodos apropiados a los eventos del administrador de juegos.
    /// </summary>
    void Start()
    {
        GameManager.instance.OnMainMenu += ActivateMainMenu;
        GameManager.instance.OnItemsMenu += ActivateItemsMenu;
        GameManager.instance.OnARPosition += ActivateARMenu;
    }

    /// <summary>
    /// Este método activa el menú principal y desactiva el menú de ítems y el menú de posición AR.
    /// </summary>
    private void ActivateMainMenu()
    {
        mainMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        mainMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        mainMenuCanvas.transform.GetChild(2).transform.DOScale(new Vector3(1, 1, 1), 0.3f);

        itemsMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.001f);
        itemsMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        itemsMenuCanvas.transform.GetChild(2).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        itemsMenuCanvas.transform.GetChild(2).transform.DOMoveY(180, 0.3f);

        ARPositionCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        ARPositionCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
    }

    /// <summary>
    /// Este método activa el menú de ítems y desactiva el menú principal y el menú de posición AR.
    /// </summary>
    private void ActivateItemsMenu()
    {
        mainMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        mainMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        mainMenuCanvas.transform.GetChild(2).transform.DOScale(new Vector3(0, 0, 0), 0.3f);

        itemsMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.001f);
        itemsMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        itemsMenuCanvas.transform.GetChild(2).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        itemsMenuCanvas.transform.GetChild(2).transform.DOMoveY(350, 0.3f);
    }

    /// <summary>
    /// El método <c>ActivateARMenu</c> activa el menú de posición AR y desactiva el menú principal y el menú de ítems.
    /// </summary>
    private void ActivateARMenu()
    {
        mainMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        mainMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        mainMenuCanvas.transform.GetChild(2).transform.DOScale(new Vector3(0, 0, 0), 0.3f);

        itemsMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0, 0, 0), 0.001f);
        itemsMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0, 0, 0), 0.5f);
        itemsMenuCanvas.transform.GetChild(2).transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        itemsMenuCanvas.transform.GetChild(2).transform.DOMoveY(180, 0.3f);

        ARPositionCanvas.transform.GetChild(0).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        ARPositionCanvas.transform.GetChild(1).transform.DOScale(new Vector3(1, 1, 1), 0.3f);
    }
}
