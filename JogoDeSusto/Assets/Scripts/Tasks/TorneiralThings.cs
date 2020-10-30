using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TorneiralThings : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private Torneira main = null;
    [SerializeField] private float correction = 0f;
    public void OnDrag (PointerEventData eventData)
    {
        main.pressControl(true, correction, (Vector3)eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        main.pressControl(false, correction, (Vector3)eventData.position);  
    }

}
