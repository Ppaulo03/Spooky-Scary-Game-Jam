using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wires : MonoBehaviour, IDragHandler, IEndDragHandler
{   
    [SerializeField] Signal connected = null;
    [SerializeField] private Transform posFin = null;
    [SerializeField] private RectTransform  wire = null;
    [SerializeField] private string Targetname = "";
    private Vector3 posInicial;

    private float width, withInitial;
    private void Start() {
        posInicial = transform.localPosition;
        withInitial = wire.sizeDelta.x;
        width = withInitial;
    }
    public void OnDrag (PointerEventData eventData)
    {
        this.transform.position += (Vector3)eventData.delta;
        RefreshWire();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.position != posFin.position){
            transform.localPosition = posInicial;
            RefreshWire();

        }  
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == Targetname){
            transform.position = posFin.position;
            RefreshWire();
            connected.Raise();
            this.enabled = false;
        }
    }

    private void RefreshWire(){
        Vector3 dir = transform.position - wire.transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;      
        float targetRotation = angle;
        wire.rotation = Quaternion.Euler(0,0, targetRotation);
        width = Mathf.Pow( (transform.localPosition.x - wire.localPosition.x), 2f) + Mathf.Pow( (transform.localPosition.y - wire.localPosition.y), 2f);
        width = Mathf.Sqrt(width);

        wire.sizeDelta = new Vector2 (width, wire.sizeDelta.y);
    }
}
