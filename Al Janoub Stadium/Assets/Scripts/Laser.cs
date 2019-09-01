using UnityEngine;

[ExecuteInEditMode]
public class Laser : MonoBehaviour {

    [SerializeField]
    private Color _color = Color.red;

    private LineRenderer _lr;
    private Renderer _renderer;

    private void Awake() {
        _renderer = GetComponentInChildren<Renderer>();

        _renderer.sharedMaterial.SetColor("_TintColor", _color);
    }

    private void Start() {
        _lr = GetComponentInChildren<LineRenderer>();
    }

    private void Update() {
        _lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit)) {
            if (hit.collider) {
                _lr.SetPosition(1, hit.point);
            }
        } else _lr.SetPosition(1, transform.forward * 5000);
    }

    private void OnValidate() {
        _renderer = GetComponentInChildren<Renderer>();

        _renderer.sharedMaterial.SetColor("_TintColor", _color);
    }

}