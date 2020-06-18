using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionShop : MonoBehaviour
{


    [Header("Shop UI elements")]

    public GameObject openShop;
    public GameObject minionShop;
    public Text zombieCText;
    public Text skeletonCText;
    public Text ghostCText;
    private bool shopActive = false;

    [Header("Variables")]

    public int zombieCost = 5;
    public int skeletonCost = 10;
    public int ghostCost = 15;

    [Header("Prefabs")]

    public Transform summoningPoint;
    public GameObject zombie;
    public GameObject skeleton;
    public GameObject ghost;

    // Start is called before the first frame update
    void Start()
    {
        openShop.SetActive(true);
        minionShop.SetActive(false);
        zombieCText.text = "" + zombieCost;
        skeletonCText.text = "" + skeletonCost;
        ghostCText.text = "" + ghostCost;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleShop();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(ScoreManager.Instance.GetScore(ScoreType.Coin) >= zombieCost)
            {
                ScoreManager.Instance.RemoveScore(zombieCost, ScoreType.Coin);
                SpawnMinion(zombie);
                
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (ScoreManager.Instance.GetScore(ScoreType.Coin) >= skeletonCost)
            {
                ScoreManager.Instance.RemoveScore(skeletonCost, ScoreType.Coin);
                SpawnMinion(skeleton);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ScoreManager.Instance.GetScore(ScoreType.Coin) >= ghostCost)
            {
                ScoreManager.Instance.RemoveScore(ghostCost, ScoreType.Coin);
                SpawnMinion(ghost);
            }
        }
    }
    public void ToggleShop()
    {
        
        if (shopActive)
        {
            minionShop.SetActive(false);
            openShop.SetActive(true);
        }
        else
        {
            minionShop.SetActive(true);
            openShop.SetActive(false);
        }
        shopActive = !shopActive;
    }
    public void SpawnMinion(GameObject minion)
    {
        Instantiate(minion, summoningPoint.position, summoningPoint.rotation);
    }
}
