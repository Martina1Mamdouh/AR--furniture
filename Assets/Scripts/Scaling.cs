using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit;

//[RequireComponent(typeof(ARRaycastManager))]
public class Scaling : MonoBehaviour
{
    public float speed = 0.01f;
    bool ScaleUp = false;
    bool ScaleDown = false;

    void Update()
    {
        if (ScaleUp == true)
        {
            ScaleUpButton();
        }
        if (ScaleDown == true)
        {
            ScaleDOwnButton();
        }
    }

    public void ScaleDOwnButton()
    {
        GameObject.FindWithTag("Untagged").transform.localScale -= new Vector3(speed, speed, speed);
    }
    public void ScaleUpButton()
    {
        GameObject.FindWithTag("Untagged").transform.localScale += new Vector3(speed, speed, speed);
    }
    public void Up()
    {
        ScaleUp = true;
        ScaleDown = false;

    }
    public void Down()
    {
        ScaleUp = false;
        ScaleDown = true;
    }
    public void Stop()
    {

    }
}

    //[SerializeField]
    //private GameObject placedPrefab;

    //[SerializeField]
    //private GameObject welcomePanel;

    //[SerializeField]
    //private Button dismissButton;

    //[SerializeField]
    //private bool applyScalingPerObject = false;

    //[SerializeField]
    //private Slider scaleSlider;

    //[SerializeField]
    //private Text scaleTextValue;

    //[SerializeField]
    //private Button toggleOptionsButton;

    //[SerializeField]
    //private GameObject options;

    //[SerializeField]
    //private Camera arCamera;

    //private GameObject placedObject;

    //private Vector2 touchPosition = default;

    //private ARRaycastManager arRaycastManager;

    //private ARSessionOrigin aRSessionOrigin;

    //private bool onTouchHold = false;

    //private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    //private PlacementObject lastSelectedObject;

    //private GameObject PlacedPrefab
    //{
    //    get
    //    {
    //        return placedPrefab;
    //    }
    //    set
    //    {
    //        placedPrefab = value;
    //    }
    //}


    //void Awake()
    //{
    //    arRaycastManager = GetComponent<ARRaycastManager>();
    //    aRSessionOrigin = GetComponent<ARSessionOrigin>();
    //    dismissButton.onClick.AddListener(Dismiss);
    //    scaleSlider.onValueChanged.AddListener(ScaleChanged);
    //    toggleOptionsButton.onClick.AddListener(ToggleOptions);
    //}

    //private void ToggleOptions()
    //{
    //    if (options.activeSelf)
    //    {
    //        toggleOptionsButton.GetComponentInChildren<Text>().text = "O";
    //        options.SetActive(false);
    //    }
    //    else
    //    {
    //        toggleOptionsButton.GetComponentInChildren<Text>().text = "X";
    //        options.SetActive(true);
    //    }
    //}

    //private void Dismiss() => welcomePanel.SetActive(false);

    //private void ScaleChanged(float newValue)
    //{
    //    if (applyScalingPerObject)
    //    {
    //        if (lastSelectedObject != null && lastSelectedObject.Selected)
    //        {
    //            lastSelectedObject.transform.parent.localScale = Vector3.one * newValue;
    //        }
    //    }
    //    else
    //        aRSessionOrigin.transform.localScale = Vector3.one * newValue;

    //    scaleTextValue.text = $"Scale {newValue}";
    //}

    //void Update()
    //{
    //    // do not capture events unless the welcome panel is hidden or if UI is selected
    //    if (welcomePanel.activeSelf || options.activeSelf)
    //        return;

    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);

    //        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
    //            return;

    //        touchPosition = touch.position;

    //        if (touch.phase == TouchPhase.Began)
    //        {
    //            Ray ray = arCamera.ScreenPointToRay(touch.position);
    //            RaycastHit hitObject;
    //            if (Physics.Raycast(ray, out hitObject))
    //            {
    //                lastSelectedObject = hitObject.transform.GetComponent<PlacementObject>();
    //                if (lastSelectedObject != null)
    //                {
    //                    PlacementObject[] allOtherObjects = FindObjectsOfType<PlacementObject>();
    //                    foreach (PlacementObject placementObject in allOtherObjects)
    //                    {
    //                        if (placementObject != lastSelectedObject)
    //                        {
    //                            placementObject.Selected = false;
    //                        }
    //                        else
    //                            placementObject.Selected = true;
    //                    }
    //                }
    //            }
    //            if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
    //            {
    //                Pose hitPose = hits[0].pose;

    //                if (lastSelectedObject == null)
    //                {
    //                    lastSelectedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation).GetComponent<PlacementObject>();
    //                }
    //            }
    //        }

    //        if (touch.phase == TouchPhase.Moved)
    //        {
    //            if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
    //            {
    //                Pose hitPose = hits[0].pose;

    //                if (lastSelectedObject != null && lastSelectedObject.Selected)
    //                {
    //                    lastSelectedObject.transform.parent.position = hitPose.position;
    //                    lastSelectedObject.transform.parent.rotation = hitPose.rotation;
    //                }
    //            }
    //        }
    //    }
    //}

        //public GameObject ARSession;

        //public void ScaleUp()
        //{
        //    Vector3 Oscale = ARSession.transform.localScale;
        //    Vector3 Nscale = Oscale * 0.9f;
        //    ARSession.transform.localScale = Nscale;
        //}

        //public void ScaleDown()
        //{
        //    Vector3 Oscale = ARSession.transform.localScale;
        //    Vector3 Nscale = Oscale * 1.1f;
        //    ARSession.transform.localScale = Nscale;
        //}
        //public Slider scaleSlider;
        //public float scaleMinValue;
        //public float scaleMaxValue;


        //void Start()
        //{
        //    // find the sliders by name
        //    //initialize the max and min value when starting
        //    // Add a listener to the slider when value is changed


        //    scaleSlider = GameObject.Find("ScaleSlider").GetComponent<Slider>();
        //    scaleSlider.minValue = scaleMinValue;
        //    scaleSlider.maxValue = scaleMaxValue;

        //    scaleSlider.onValueChanged.AddListener(ScaleSliderUpdate);

        //}
        //void ScaleSliderUpdate(float value)
        //{
        //    transform.localScale = new Vector3(value, value, value);
        //}


        //public float placementIndicator;
        //public GameObject selectionUI;
        //// Start is called before the first frame update
        //public void ScaleSelected(float rate)
        //{
        //    selectionUI.transform.localScale += Vector3.one * rate;
        //}
        ////public GameObject Object;
        ////private bool _ZoomIn;
        ////private bool _ZoomOut;
        //////object scale speed
        ////public float Scale = 0.10f;
        //////Make object scaled big


        ////public void OnPressZoomIn()
        ////{
        ////    Object.transform.localScale += new Vector3(Scale, Scale, Scale);
        ////}

        ////public void OnReleaseZoomIn()
        ////{
        ////    _ZoomIn = false;
        ////}

        //////Make object scaled small
        ////public void OnPressZoomOut()
        ////{
        ////    Object.transform.localScale -= new Vector3(Scale, Scale, Scale);
        ////}

        ////public void OnReleaseZoomOut()
        ////{
        ////    _ZoomOut = false;
        ////}
    
