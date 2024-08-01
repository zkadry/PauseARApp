using UnityEngine;
using UnityEngine.EventSystems;

public class MoveObjects : MonoBehaviour, IPointerClickHandler
{
    private Rigidbody rb;

    private void Start()
    {
        // Corrected the typo and made sure to get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // This method is called when the object is clicked.
        // Here, you can apply a force or change the velocity as needed.
        // For example, applying a force:
        Vector3 forceDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 5f;
        rb.AddForce(forceDirection, ForceMode.VelocityChange);
        
        Debug.Log("Object clicked: " + gameObject.name);
    }
}


