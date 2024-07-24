using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButtonManager : MonoBehaviour
{
    /// <summary>
    /// El nombre del objeto.
    /// </summary>
    private string itemName;

    /// <summary>
    /// La imagen del objeto.
    /// </summary>
    private Sprite itemImage;

    /// <summary>
    /// El modelo 3D del objeto.
    /// </summary>
    private GameObject item3DModel;

    /// <summary>
    /// El administrador de interacciones de AR.
    /// </summary>
    private ARInteractionManager interactionManager;

    /// <summary>
    /// Propiedad <c>ItemName</c> que establece el nombre del objeto.
    /// </summary>
    public string ItemName {
        set 
        { 
            itemName = value;
        }
    }

    /// <summary>
    /// Propiedad <c>ItemImage</c> que establece la imagen del objeto.
    /// </summary>
    public Sprite ItemImage
    {
        set
        {
            itemImage = value;
        }
    }

    /// <summary>
    /// Propiedad <c>Item3DModel</c> que establece el modelo 3D del objeto.
    /// </summary>
    public GameObject Item3DModel
    {
        set
        {
            item3DModel = value;
        }
    }

    /// <summary>
    /// Este método inicializa el botón del objeto, estableciendo su texto e imagen, y añadiendo oyentes de clic al botón.
    /// </summary>
    void Start()
    {
        transform.GetChild(0).GetComponent<Text>().text = itemName;
        transform.GetChild(1).GetComponent<RawImage>().texture = itemImage.texture;

        var button = GetComponent<Button>();
        button.onClick.AddListener(GameManager.instance.ARPosition);
        button.onClick.AddListener(Create3DModel);

        interactionManager = FindObjectOfType<ARInteractionManager>();
    }

    /// <summary>
    /// Este método crea el modelo 3D del objeto en el entorno de AR.
    /// </summary>
    private void Create3DModel()
    {
        interactionManager.Item3DModel = Instantiate(item3DModel);
    }
}
