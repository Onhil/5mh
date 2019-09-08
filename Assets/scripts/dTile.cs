using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class dTile : Tile
{
    #region Properties
    public ITilemap tileMap;
    public Vector3Int tilePos;
    #endregion

    #region Tile Overriding
    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go) {
        this.tileMap = tilemap;
        this.tilePos = position;

        return base.StartUp(position, tilemap, go);
    }
    #endregion

    
    #region Implementation
    public void destroyGrandma() {
        base.sprite = null;
    }
    #endregion


    #region Asset DataBase
    [MenuItem("Assets/dtile")]
    public static void CreateDTile() {
        string path = EditorUtility.SaveFilePanelInProject("Save Destructible Tile", "DestructibleTile_", "Asset", "Save Destructible Tile", "assets");
        if (path == "") {
            return;
        }

        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<dTile>(), path);
    }
    #endregion
}
