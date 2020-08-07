using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.test_tavern.Scripts.Types;

public class GManager : MonoBehaviour
{
    private Dictionary<int, Item> Items = new Dictionary<int, Item>();
    private Dictionary<int, int> CutRecipes = new Dictionary<int, int>();
    private Dictionary<int, int> GrillRecipes = new Dictionary<int, int>();
    private Dictionary<CraftRecipe<int,int,int>, int> CraftRecipes = new Dictionary<CraftRecipe<int, int, int>, int>();

    void Awake()
    {
        RegisterGameItems();
        RegisterGameCutRecipes();
        RegisterGameGrillRecipes();
        RegisterGameCraftRecipes();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Register
    void RegisterGameItems()
    {
        RegisterItem(0, "empty");
        RegisterItem(1, "minced meat");
        RegisterItem(2, "salat");
        RegisterItem(3, "stake");
        RegisterItem(4, "cutlet");
        RegisterItem(5, "Fired vegetables");
        RegisterItem(6, "hot ​​bread");
        RegisterItem(7, "burger");
        RegisterItem(8, "raw meat");
        RegisterItem(9, "vegibatle");
        RegisterItem(10, "Bread");
        RegisterItem(11, "Coal");
        RegisterItem(12, "Garbage");
    }

    void RegisterGameCutRecipes()
    {
        RegisterCutRecipe(8, 1);
        RegisterCutRecipe(9, 2);
    }

    void RegisterGameGrillRecipes()
    {
        RegisterGrillRecipe(8, 3);
        RegisterGrillRecipe(1, 4);
        RegisterGrillRecipe(9, 5);
        RegisterGrillRecipe(10, 6);
    }

    void RegisterGameCraftRecipes()
    {
        RegisterCraftRecipe(4, 2, 6, 7);
    }



    //items
    public void RegisterItem(int id, string name)
    {
        Item itm = new Item(name);
        Items.Add(id, itm);
    }

    public Item ItemID(int id)
    {
        return Items[id];
    }


    //Cut
    public bool IsCutRecipeExists(int sourceId)
    {
        return CutRecipes.ContainsKey(sourceId);
    }

    public int CutRecipe(int sourceId)
    {
        return CutRecipes[sourceId];
    }

    public void RegisterCutRecipe(int sourceId, int targetId)
    {
        CutRecipes.Add(sourceId, targetId);
    }


    //Grill
    public bool IsGrillRecipeExists(int sourceId)
    {
        return GrillRecipes.ContainsKey(sourceId);
    }

    public int GrillRecipe(int sourceId)
    {
        return GrillRecipes[sourceId];
    }

    public void RegisterGrillRecipe(int sourceId, int targetId)
    {
        GrillRecipes.Add(sourceId, targetId);
    }


    //Craft
    public bool IsCraftRRecipeExists(int sourceId1, int sourceId2, int sourceId3)
    {
        CraftRecipe<int, int, int> Recipe = new CraftRecipe<int, int, int>(sourceId1, sourceId2, sourceId3);
        return CraftRecipes.ContainsKey(Recipe);
    }

    public int CraftRecipe(int sourceId1, int sourceId2, int sourceId3)
    {
        CraftRecipe<int, int, int> Recipe = new CraftRecipe<int, int, int>(sourceId1, sourceId2, sourceId3);
        return CraftRecipes[Recipe];
    }

    public void RegisterCraftRecipe(int sourceId1, int sourceId2, int sourceId3, int targetId)
    {
        CraftRecipe<int, int, int> Recipe = new CraftRecipe<int, int, int>(sourceId1, sourceId2, sourceId3);
        CraftRecipes.Add(Recipe, targetId);
    }
}
