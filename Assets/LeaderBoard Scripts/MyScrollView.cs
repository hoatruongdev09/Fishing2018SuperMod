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
    private Vector3 distanceToPointer;

    private void Start() {
        backGroundImage = GetComponent<Image>();

    }

    private void Update() {
        if (isDragging) {
            if (horizontal) {
                content.rectTransform.position = Vector3.Lerp(content.rectTransform.position, new Vector3(pointerPosition.x - distanceToPointer.x, content.rectTransform.position.y), smoothSpeed * Time.deltaTime);
            }
            if (vertical) {
                content.rectTransform.position = Vector3.Lerp(content.rectTransform.position, new Vector3(content.rectTransform.position.x, pointerPosition.y - distanceToPointer.y), smoothSpeed * Time.deltaTime);
            }
        }
    }
    public void OnDrag(PointerEventData eventData) {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backGroundImage.rectTransform, eventData.position, eventData.pressEventCamera, out pos)) {
            isDragging = true;
            pointerPosition = eventData.position;
        }

    }

    public void OnPointerDown(PointerEventData eventData) {
        distanceToPointer = (Vector3)eventData.position - content.rectTransform.position;
    }

    public void OnPointerUp(PointerEventData eventData) {
        isDragging = false;

        //throw new System.NotImplementedException();
    }
}
