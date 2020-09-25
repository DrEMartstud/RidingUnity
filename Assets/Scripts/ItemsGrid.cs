using UnityEngine;

public class ItemsGrid : MonoBehaviour {
    private Item flyingItem;
    private Item[,] grid;
    public Vector2Int GridSize = new Vector2Int(4, 5);
    private Camera mainCamera;

    private void Awake() {
        grid = new Item[GridSize.x, GridSize.y];
        mainCamera = Camera.main;
    }

    private void Update() {
        if (flyingItem != null) {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (groundPlane.Raycast(ray, out var position)) {
                var worldPosition = ray.GetPoint(position);

                var x = Mathf.RoundToInt(worldPosition.x);
                var y = Mathf.RoundToInt(worldPosition.z);

                var available = true;
                if (x < 0 || x > GridSize.x - flyingItem.Size.x) available = false;
                if (y < 0 || y > GridSize.y - flyingItem.Size.y) available = false;

                if (available && IsPlaceTaken(x, y)) available = false;

                flyingItem.transform.position = new Vector3(x, 0, y);
                flyingItem.SetTransparent(available);
                if (available && Input.GetMouseButtonDown(0)) PlaceFlyingItem(x, y);
            }
        }
    }

    public void StartPlacingItem(Item itemPrefab) {
        if (flyingItem != null) Destroy(flyingItem.gameObject);

        flyingItem = Instantiate(itemPrefab);
    }

    private bool IsPlaceTaken(int placeX, int placeY) {
        for (var x = 0; x < flyingItem.Size.x; x++)
        for (var y = 0; y < flyingItem.Size.y; y++)
            if (grid[placeX + x, placeY + y] != null)
                return true;
        return false;
    }

    private void PlaceFlyingItem(int placeX, int placeY) {
        for (var x = 0; x < flyingItem.Size.x; x++)
        for (var y = 0; y < flyingItem.Size.y; y++)
            grid[placeX + x, placeY + y] = flyingItem;
        flyingItem.SetNormal();
        flyingItem = null;
    }
}