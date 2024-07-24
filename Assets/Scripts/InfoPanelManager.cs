using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InfoPanelManager : MonoBehaviour
{
    public GameObject infoPanel; // Referencia al panel de informaci�n en la interfaz
    public Button infoButton; // Referencia al bot�n que activa el panel de informaci�n
    public Button closeButton; // Referencia al bot�n que cierra el panel de informaci�n
    public GameObject scrollViewContent; // Referencia al contenido del ScrollView
    public GameObject modelInfoPrefab; // Prefab del elemento de informaci�n del modelo

    public List<ModelData> modelList; // Lista de modelos 3D

    void Start()
    {
        // Aseg�rate de que el panel est� desactivado al inicio para ocultarlo
        infoPanel.SetActive(false);

        // Agrega listeners a los botones para que respondan a los eventos de clic
        infoButton.onClick.AddListener(ShowInfoPanel);
        closeButton.onClick.AddListener(HideInfoPanel);
    }

    // M�todo para mostrar el panel de informaci�n
    void ShowInfoPanel()
    {
        // Limpiar el contenido anterior del ScrollView
        foreach (Transform child in scrollViewContent.transform)
        {
            Destroy(child.gameObject);
        }

        // Mostrar el panel de informaci�n
        infoPanel.SetActive(true);

        // Crear elementos de informaci�n para cada modelo 3D en la lista
        foreach (var model in modelList)
        {
            // Instanciar el prefab del elemento de informaci�n del modelo dentro del ScrollView
            GameObject modelInfoObject = Instantiate(modelInfoPrefab, scrollViewContent.transform);

            // Obtener referencia al componente de texto dentro del prefab para actualizarlo con la informaci�n del modelo
            Text modelInfoText = modelInfoObject.GetComponentInChildren<Text>();

            // Actualizar el texto con la informaci�n del modelo 3D
            modelInfoText.text = $"Obra: {model.modelName}\n\n Autor: {model.modelAutor}\n\n {model.modelDescription}\n\n Medidas: {model.modelMeasures}\n\n Peso: {model.modelWeight}";

            // Obtener referencia al componente de imagen dentro del prefab para mostrar la imagen del modelo 3D
            Image modelImage = modelInfoObject.GetComponentInChildren<Image>();

            // Asignar la imagen del modelo 3D al componente de imagen
            modelImage.sprite = model.modelImage;

            // Asegurar que el nuevo elemento se ajuste correctamente dentro del ScrollView
            LayoutRebuilder.ForceRebuildLayoutImmediate(scrollViewContent.GetComponent<RectTransform>());
        }
    }

    // M�todo para ocultar el panel de informaci�n
    public void HideInfoPanel()
    {
        // Desactivar el panel de informaci�n para ocultarlo de la interfaz
        infoPanel.SetActive(false);
    }
}
