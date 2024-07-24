using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARInteractionManager : MonoBehaviour
{
    /// <summary>
    /// Cámara utilizada para la realidad aumentada.
    /// </summary>
    [SerializeField] private Camera aRCamera;
    private ARRaycastManager aRRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject aRPointer;
    private GameObject item3DModel;
    private GameObject itemSelected;

    private bool isInitialPosition;
    private bool isOverUI;
    private bool isOver3DModel;

    private float initialDistance;

    private Vector2 initialTouchPos;
    private Vector3 initialScale;

    /// <summary>
    /// Propiedad para configurar y posicionar el modelo 3D del ítem.
    /// </summary>
    public GameObject Item3DModel { 
        set
        {
            item3DModel = value;
            item3DModel.transform.position = aRPointer.transform.position;
            item3DModel.transform.parent = aRPointer.transform;
            isInitialPosition = true;
        } 
    }


    void Start()
    {
        // Obtener el puntero de realidad aumentada y configurar el raycast manager.
        aRPointer = transform.GetChild(0).gameObject;
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();

        // Suscribirse al evento OnMainMenu del GameManager para establecer la posición del ítem.
        GameManager.instance.OnMainMenu += SetItemPosition;
    }


    void Update()
    {
        // Si el ítem está en posición inicial, realizar un raycast al centro de la pantalla para establecer la posición inicial.
        if (isInitialPosition)
        {
            Vector2 middlePointScreen = new Vector2(Screen.width/2, Screen.height/2);
            aRRaycastManager.Raycast(middlePointScreen, hits, TrackableType.Planes);
            if(hits.Count > 0)
            {
                transform.position = hits[0].pose.position;
                transform.rotation = hits[0].pose.rotation;
                aRPointer.SetActive(true);
                isInitialPosition = false;
            }
        }

        // Manejo de los gestos táctiles para mover, escalar y rotar el modelo 3D del ítem.
        if (Input.touchCount > 0)
        {
            Touch touchOne = Input.GetTouch(0);
            if(touchOne.phase == TouchPhase.Began)
            {
                var touchPosition = touchOne.position;
                isOverUI = isTapOverUI(touchPosition);
                isOver3DModel = isTapOver3DModel(touchPosition);
            }

            if(touchOne.phase == TouchPhase.Moved)
            {
                if (aRRaycastManager.Raycast(touchOne.position, hits, TrackableType.Planes))
                {
                    Pose hitPose = hits[0].pose;
                    if (!isOverUI && isOver3DModel)
                    {
                        transform.position = hitPose.position;
                    }
                }
            }

            if(Input.touchCount == 2)
            {
                Touch touchTwo = Input.GetTouch(1);
                if(touchOne.phase == TouchPhase.Began || touchTwo.phase == TouchPhase.Began)
                {
                    initialDistance = Vector2.Distance(touchOne.position, touchTwo.position);
                    initialScale = item3DModel.transform.localScale;
                    initialTouchPos = touchTwo.position - touchOne.position;
                }

                if(touchOne.phase == TouchPhase.Moved || touchTwo.phase == TouchPhase.Moved)
                {
                    var currentDistance = Vector2.Distance(touchOne.position, touchTwo.position);
                    if (Mathf.Approximately(initialDistance, 0))
                    {
                        return;
                    }
                    var factor = currentDistance / initialDistance;
                    item3DModel.transform.localScale = initialScale * factor;
                    Vector2 currentTouchPos = touchTwo.position - touchOne.position;
                    float angle = Vector2.SignedAngle(initialTouchPos, currentTouchPos);
                    item3DModel.transform.rotation = Quaternion.Euler(0, item3DModel.transform.eulerAngles.y - angle, 0);
                    initialTouchPos = currentTouchPos;
                }
            }

            // Si se selecciona un modelo 3D y no hay otro modelo 3D seleccionado ni se está tocando sobre la interfaz de usuario, activar el menú de posición AR.
            if (isOver3DModel && item3DModel == null && !isOverUI)
            {
                GameManager.instance.ARPosition();
                item3DModel = itemSelected;
                itemSelected = null;
                aRPointer.SetActive(true);
                transform.position = item3DModel.transform.position;
                item3DModel.transform.parent = aRPointer.transform;
            }
        }
    }

    /// <summary>
    /// Método para determinar si se toca sobre un modelo 3D.
    /// </summary>
    private bool isTapOver3DModel(Vector2 touchPosition)
    {
        Ray ray = aRCamera.ScreenPointToRay(touchPosition);
        if(Physics.Raycast(ray, out RaycastHit hit3DModel))
        {
            if (hit3DModel.collider.CompareTag("Item"))
            {
                itemSelected = hit3DModel.transform.gameObject;
                return true;
            }
        }

        return false;

    }

    /// <summary>
    /// Método para determinar si se toca sobre la interfaz de usuario.
    /// </summary>
    private bool isTapOverUI(Vector2 touchPosition)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touchPosition.x, touchPosition.y);

        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, result);

        return result.Count > 0;
    }

    /// <summary>
    /// Método para establecer la posición del ítem en la escena de realidad aumentada.
    /// </summary>
    private void SetItemPosition()
    {
        if(item3DModel != null)
        {
            item3DModel.transform.parent = null;
            aRPointer.SetActive(false);
            item3DModel = null;
        }
    }

    /// <summary>
    /// Método para eliminar el ítem seleccionado.
    /// </summary>
    public void DeleteItem()
    {
        Destroy(item3DModel);
        aRPointer.SetActive(false);
        GameManager.instance.MainMenu();
    }
}
