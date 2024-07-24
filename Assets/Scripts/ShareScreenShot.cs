using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ShareScreenShot : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject itemsMenuCanvas;
    [SerializeField] private GameObject aRMenuCanvas;
    private ARPointCloudManager aRPointCloudManager;

    // Método Start se llama antes del primer frame
    void Start()
    {
        // Buscar y asignar el ARPointCloudManager en la escena
        aRPointCloudManager = FindObjectOfType<ARPointCloudManager>();
    }

    // Método Update se llama una vez por frame
    void Update()
    {
        // No realiza ninguna acción en este caso
    }

    // Método para capturar una captura de pantalla y compartir
    public void TakeScreenshot()
    {
        // Apagar los contenidos de AR antes de capturar la captura de pantalla
        TurnOnOffArContents();
        // Iniciar la rutina para capturar la captura de pantalla y compartir
        StartCoroutine(TakeScreenshotAndShare());
    }

    // Método para activar/desactivar los contenidos de AR y los menús principales
    private void TurnOnOffArContents()
    {
        // Obtener todos los puntos AR trackeables y alternar su estado activo
        var points = aRPointCloudManager.trackables;
        foreach (var point in points)
        {
            point.gameObject.SetActive(!point.gameObject.activeSelf);
        }
        // Alternar la visibilidad de los canvas de los menús principales y de AR
        mainMenuCanvas.SetActive(!mainMenuCanvas.activeSelf);
        itemsMenuCanvas.SetActive(!itemsMenuCanvas.activeSelf);
        aRMenuCanvas.SetActive(!aRMenuCanvas.activeSelf);
    }

    // Rutina para capturar la captura de pantalla y compartir
    private IEnumerator TakeScreenshotAndShare()
    {
        // Esperar al final del frame actual antes de tomar la captura de pantalla
        yield return new WaitForEndOfFrame();

        // Crear una textura 2D con el tamaño de la pantalla y formato RGB24
        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        // Leer los pixeles de la pantalla en la textura
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        // Guardar la captura de pantalla en el almacenamiento temporal como archivo PNG
        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // Liberar la memoria de la textura para evitar fugas de memoria
        Destroy(ss);

        // Compartir la captura de pantalla usando NativeShare (plugin de terceros)
        new NativeShare().AddFile(filePath)
            .SetSubject("Asunto del mensaje")
            .SetCallback((result, shareTarget) => Debug.Log("Resultado de compartir: " + result + ", aplicación seleccionada: " + shareTarget))
            .Share();

        // Restaurar la visibilidad de los contenidos de AR y los menús principales después de compartir
        TurnOnOffArContents();
        // Share on WhatsApp only, if installed (Android only)
        //if( NativeShare.TargetExists( "com.whatsapp" ) )
        //	new NativeShare().AddFile( filePath ).AddTarget( "com.whatsapp" ).Share();
    }
}
