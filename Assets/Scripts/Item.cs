using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que representa un objeto en el juego.
/// </summary>
[CreateAssetMenu]

public class Item : ScriptableObject
{
    /// <summary>
    /// El nombre del objeto.
    /// </summary>
    public string ItemName;

    /// <summary>
    /// La imagen asociada al objeto.
    /// </summary>
    public Sprite ItemImage;

    /// <summary>
    /// El modelo 3D asociado al objeto.
    /// </summary>
    public GameObject Item3DModel;

}
