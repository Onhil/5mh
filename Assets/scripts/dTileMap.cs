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

        foreach(Vector3Int pos in tileMap.cellBounds.allPositionsWithin) {
            TileBase t = tileMap.GetTile(pos);

            if(!Equals(t, null)) {
                if (t is dTile) {
                    dTile dt = Instantiate(t) as dTile;
                    dt.StartUp(pos, dt.tileMap, dt.gameObject);
                    tileMap.SetTile(pos, dt);
                }
            }
        }
    }

    public void Destroy(Player player, Vector3 contactPoint) {
        TileBase tileToDestroy = tileMap.GetTile(grid.WorldToCell(contactPoint));
        Debug.Log(contactPoint);
        if (!Equals(tileToDestroy, null)) {
            Debug.Log("destroy");
            if (tileToDestroy is dTile) {
                Debug.Log("destroy");
                ((dTile)tileToDestroy).destroyGrandma();

                tileMap.RefreshTile(((dTile)tileToDestroy).tilePos);
            }
        }
    }
}
