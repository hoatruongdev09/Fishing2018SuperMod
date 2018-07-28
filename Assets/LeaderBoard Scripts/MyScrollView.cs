using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MyScrollView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {

    public Image content;
    public bool horizontal = false;
    public bool vertical = false;
    public float smoothSpeed = 1;

    private Image backGroundImage;
    private bool isDragging;

    private Vector3 pointerPosition;
    public Vector3 deltaPosition;
    public Vector3 lastPosition;

    private void Start() {
        backGroundImage = GetComponent<Image>();
        lastPosition = content.rectTransform.position;
        //deltaPosition = content.rectTransform.position - lastPosition;
    }

    private void Update() {
        if (isDragging) {
            if (horizontal) {
                content.rectTransform.position = Vector3.Lerp(content.rectTransform.position, new Vector3(pointerPosition.x, content.rectTransform.position.y) + deltaPosition, smoothSpeed * Time.deltaTime);
            }
            if (vertical) {
                content.rectTransform.position = Vector3.Lerp(content.rectTransform.position, new Vector3(content.rectTransform.position.x, pointerPosition.y) + deltaPosition, smoothSpeed * Time.deltaTime);
            }
        }
    }
    public void OnDrag(PointerEventData eventData) {
        isDragging = true;
        pointerPosition = eventData.position;

    }

    public void OnPointerDown(PointerEventData eventData) {

    }

    public void OnPointerUp(PointerEventData eventData) {
        isDragging = false;
        deltaPosition = content.rectTransform.position - lastPosition;
        lastPosition = content.rectTransform.position;
        //throw new System.NotImplementedException();
    }
}
