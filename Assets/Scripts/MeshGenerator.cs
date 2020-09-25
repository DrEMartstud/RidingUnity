using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour {
    private Mesh _mesh;
    private int[] _triangles;
    private Vector3[] _vertices;

    private void Start() {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
        CreateShape();
        UpdateMesh();
    }

    private void CreateShape() {
        _vertices = new[] {new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 0), new Vector3(1, 0, 1)};
        _triangles = new[] {0, 1, 2, 1, 3, 2};
    }

    private void UpdateMesh() {
        _mesh.Clear();

        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;
        _mesh.RecalculateNormals();
    }
}