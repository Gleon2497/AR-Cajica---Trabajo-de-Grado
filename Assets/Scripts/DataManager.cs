using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>(); // Lista de ítems para los botones
    [SerializeField] private GameObject buttonContainer; // Contenedor de botones en ScrollView
    [SerializeField] private ItemButtonManager itemButtonManager; // Prefab del administrador de botones de ítems


    void Start()
    {
        // Suscribirse al evento OnItemsMenu del GameManager para crear los botones cuando se active el menú de ítems.
        GameManager.instance.OnItemsMenu += CreateButtons;
    }

    /// <summary>
    /// Método que crea botones para cada ítem en la lista de ítems.
    /// Se llama cuando se activa el evento OnItemsMenu del GameManager.
    /// </summary>
    private void CreateButtons()
    {
        foreach (var item in items)
        {
            // Instanciar un nuevo botón de ítem usando el prefab itemButtonManager.
            ItemButtonManager itemButton = Instantiate(itemButtonManager, buttonContainer.transform);

            // Configurar los datos del ítem en el botón recién creado.
            itemButton.ItemName = item.ItemName;
            itemButton.ItemImage = item.ItemImage;
            itemButton.Item3DModel = item.Item3DModel;

            // Asignar un nombre único al botón basado en el nombre del ítem.
            itemButton.name = item.ItemName;
        }

        // Desuscribirse del evento OnItemsMenu para evitar múltiples llamadas a este método.
        GameManager.instance.OnItemsMenu -= CreateButtons;
    }

}
