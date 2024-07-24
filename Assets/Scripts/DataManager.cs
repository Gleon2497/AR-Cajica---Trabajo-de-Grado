using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>(); // Lista de �tems para los botones
    [SerializeField] private GameObject buttonContainer; // Contenedor de botones en ScrollView
    [SerializeField] private ItemButtonManager itemButtonManager; // Prefab del administrador de botones de �tems


    void Start()
    {
        // Suscribirse al evento OnItemsMenu del GameManager para crear los botones cuando se active el men� de �tems.
        GameManager.instance.OnItemsMenu += CreateButtons;
    }

    /// <summary>
    /// M�todo que crea botones para cada �tem en la lista de �tems.
    /// Se llama cuando se activa el evento OnItemsMenu del GameManager.
    /// </summary>
    private void CreateButtons()
    {
        foreach (var item in items)
        {
            // Instanciar un nuevo bot�n de �tem usando el prefab itemButtonManager.
            ItemButtonManager itemButton = Instantiate(itemButtonManager, buttonContainer.transform);

            // Configurar los datos del �tem en el bot�n reci�n creado.
            itemButton.ItemName = item.ItemName;
            itemButton.ItemImage = item.ItemImage;
            itemButton.Item3DModel = item.Item3DModel;

            // Asignar un nombre �nico al bot�n basado en el nombre del �tem.
            itemButton.name = item.ItemName;
        }

        // Desuscribirse del evento OnItemsMenu para evitar m�ltiples llamadas a este m�todo.
        GameManager.instance.OnItemsMenu -= CreateButtons;
    }

}
