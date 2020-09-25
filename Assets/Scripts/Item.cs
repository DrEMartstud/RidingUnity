using UnityEngine;

public class Item : MonoBehaviour {
    public Renderer MainRenderer;
    public Vector2Int Size = Vector2Int.one;

    private void OnDrawGizmos() {
        for (var x = 0; x < Size.x; x++)
        for (var y = 0; y < Size.y; y++) {
            Gizmos.color = new Color(0f, 1f, 0f, 0.3f);
            Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));
        }
    }

    public void SetTransparent(bool available) { MainRenderer.material.color = available ? Color.green : Color.red; }

    public void SetNormal() { MainRenderer.material.color = Color.white; }
}