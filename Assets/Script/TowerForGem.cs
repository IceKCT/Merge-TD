using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerForGem : MonoBehaviour
{
    
    public int gemInTower = 0;
    public GameObject UitowerGem;

    public float range;

    private List<BaseTower> towerInrangeForAuraTower = new List<BaseTower>();
    private List<BaseTower> towerInrangeForBurstTower = new List<BaseTower>();
    private List<BaseTower> towerInrangeForAoeTower = new List<BaseTower>();

    public LayerMask auraTower, burstTower, aoeTower;
    public bool isRuby, isSapphire, isEmerald, isDiamond = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isRuby == true)
        {
            RubyAura();
        }else if(isSapphire == true)
        {
            SapphireAura();
        }else if(isDiamond == true)
        {
            DiamondAura();
        }else if (isEmerald == true)
        {
            EmeraldAura();
            isEmerald = false;
        }
        else
        {

        }
        
    }

    public void RubyAura()
    {
        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, range, auraTower);
        foreach (Collider hit in hitcolliders)
        {
            BaseTower tower = hit.gameObject.GetComponent<BaseTower>();
            if (tower != null && !towerInrangeForAuraTower.Contains(tower))
            {
                towerInrangeForAuraTower.Add(tower);
            }
        }
        for (int i = towerInrangeForAuraTower.Count - 1; i >= 0; i--)
        {
            BaseTower tower = towerInrangeForAuraTower[i];
            if (tower == null || Vector3.Distance(transform.position, tower.transform.position) > range)
            {
                towerInrangeForAuraTower.RemoveAt(i);
            }

        }

        if(isRuby == true)
        {
           
            foreach (BaseTower tower in towerInrangeForAuraTower)
            {
                if(tower.getBonusFromRuby == false)
                {
                    tower.range += 30;
                    tower.getBonusFromRuby = true;

                }
                else
                {

                }
                
            }
        }
        else
        {

        }
      
    }
    public void EmeraldAura()
    {
       
        Enemy.BonusHero(10);
    }
    public void DiamondAura()
    {
        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, range, burstTower);
        foreach (Collider hit in hitcolliders)
        {
            BaseTower tower = hit.gameObject.GetComponent<BaseTower>();
            if (tower != null && !towerInrangeForBurstTower.Contains(tower))
            {
                towerInrangeForBurstTower.Add(tower);
            }
        }
        for (int i = towerInrangeForBurstTower.Count - 1; i >= 0; i--)
        {
            BaseTower tower = towerInrangeForBurstTower[i];
            if (tower == null || Vector3.Distance(transform.position, tower.transform.position) > range)
            {
                towerInrangeForBurstTower.RemoveAt(i);
            }

        }

        if (isDiamond == true)
        {
            foreach (BaseTower tower in towerInrangeForBurstTower)
            {
                if(tower.getBonusFromDiamond == false)
                {
                    tower.bonusExplodeRadius += 15;
                    tower.getBonusFromDiamond = true;
                }
                else
                {

                }
                
            }
        }
        else
        {

        }
    }
    public void SapphireAura()
    {
        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, range, aoeTower);
        foreach (Collider hit in hitcolliders)
        {
            BaseTower tower = hit.gameObject.GetComponent<BaseTower>();
            if (tower != null && !towerInrangeForAoeTower.Contains(tower))
            {
                towerInrangeForAoeTower.Add(tower);
            }
        }
        for (int i = towerInrangeForAoeTower.Count - 1; i >= 0; i--)
        {
            BaseTower tower = towerInrangeForAoeTower[i];
            if (tower == null || Vector3.Distance(transform.position, tower.transform.position) > range)
            {
                towerInrangeForAoeTower.RemoveAt(i);
            }

        }

        if (isSapphire == true)
        {
            foreach (BaseTower tower in towerInrangeForAoeTower)
            {
                if (tower.getBonusFromSapphire == false)
                {
                    tower.range += 30;
                    tower.getBonusFromSapphire = true;
                }
                else
                {

                }
               
            }
        }
        else
        {

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }
    public void OnMouseDown()
    {
        GemTowerDrop.instance.SelectedTowerGem(this);
        UitowerGem.transform.position = new Vector3(960, 540, 0);
    }
}
