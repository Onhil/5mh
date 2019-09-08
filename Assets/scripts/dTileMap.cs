using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class dTileMap : MonoBehaviour
{
    #region Properties
    private Tilemap tileMap;
    private GridLayout grid;
    private Vector3Int tilePos;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        tileMap = GetComponent<Tilemap>();
        grid = GetComponentInParent<GridLayout>();
    }

    public void Destroy(Vector3 contactPoint) {
        TileBase tileToDestroy = tileMap.GetTile(grid.WorldToCell(contactPoint));
        if (!Equals(tileToDestroy, null)) {
            if (tileToDestroy is dTile) {
                ((dTile)tileToDestroy).destroyGrandma();

                tileMap.RefreshTile(((dTile)tileToDestroy).tilePos);
            }
        }
    }
}
