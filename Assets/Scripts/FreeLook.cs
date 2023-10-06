using UnityEngine;

public class FreeLook : MonoBehaviour
{
    public float moveSpeed = 5.0f;           // Vitesse de déplacement
    public float sensitivity = 2.0f;         // Sensibilité de la souris
    public bool invertY = false;             // Inversion de l'axe Y

    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 angles = transform.eulerAngles;
        xRotation = angles.y;
        yRotation = angles.x;
    }

    private void Update()
    {
        // Rotation basée sur le mouvement de la souris
        xRotation += Input.GetAxis("Mouse X") * sensitivity;
        yRotation -= (invertY ? -1 : 1) * Input.GetAxis("Mouse Y") * sensitivity;
        yRotation = Mathf.Clamp(yRotation, -90, 90);

        transform.eulerAngles = new Vector3(yRotation, xRotation, 0.0f);

        // Mouvement basé sur les touches du clavier
        Vector3 moveDirection = new Vector3(
            Input.GetAxis("Horizontal"),
            (Input.GetKey(KeyCode.E) ? 1.0f : 0) - (Input.GetKey(KeyCode.Q) ? 1.0f : 0),
            Input.GetAxis("Vertical")
        ).normalized;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self);
    }
}
