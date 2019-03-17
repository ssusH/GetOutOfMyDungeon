using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterDesign : ScriptableObject {


    [MenuItem("DesignAsset/Create CharacterDesign Instance")]
    public static void CreateExampleAssetInstance()
    {
        var exampleAsset = CreateInstance<CharacterDesign>();

        AssetDatabase.CreateAsset(exampleAsset, "Assets/DesignObject/Character/CharacterDesignAsset.asset");
        AssetDatabase.Refresh();
    }

    public string CharecterName = "Defalut";
    public int BaseHealth = 0;
    public int BaseMana = 0;
    public int BaseWealth = 0;
    public int BaseAttack = 0;
    public int BaseDefense = 0;
    public int BaseSpeed = 0;

  




   

}
