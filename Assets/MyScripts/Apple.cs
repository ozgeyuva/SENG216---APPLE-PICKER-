using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class Apple : MonoBehaviour
{
    [SerializeField] private float bottomMargin = 0.5f;

    public UnityEvent onAppleMissed = new UnityEvent();

    private Camera mainCamera;
    private bool missed;

    private void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("MainCamera etiketli kamera bulunamadı.", this);
            enabled = false;
        }
    }

    private void Update()
    {
        if (missed)
            return;

        Vector3 viewportPosition =
            mainCamera.WorldToViewportPoint(transform.position);

        float margin = bottomMargin /
            (2f * mainCamera.orthographicSize);

        if (viewportPosition.z > 0f &&
            viewportPosition.y < -margin)
        {
            missed = true;

            onAppleMissed.Invoke();

            Destroy(gameObject);
        }
    }
}