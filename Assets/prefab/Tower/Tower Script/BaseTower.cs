using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    private Transform target;

    [Header("General")]
    public float range = 15f;
    public float attackDamage;
    public float bonusAttack;
    public float bonusExplodeRadius;

    [Header("Use Bullet (Defaul)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public float turnSpeed = 5f;

    [Header("SomeThing else")]
    public Transform firePoint;
    public float priceTower;

    [HideInInspector]
    public bool lvl2BaseTower = false;
    public bool lvl3BaseTower = false;
    public bool lvlBaseMax = false;
    public bool lvl2BurstTower = false;
    public bool lvl3BurstTower = false;
    public bool lvlBurstMax = false;
    public bool lvl2Aoe = false;
    public bool lvl3Aoe = false;
    public bool lvlMaxAoe = false;

    Resercher rs;
    TowerInput towerInput;
    public GameObject uiTower;

    public bool isFire,isFire2,isFire3,isPoison,isPoison2,isPoison3, isAcid,isAcid2,isAcid3,isElec,isElec2,isElec3,isBurst,isBurst2,isBurst3;

    private GameObject handElement, mainHand, elementButton, mainButton;

    [Header("Status")]
    public bool isAura;
   

    [Header("Aura Option")]
    public LayerMask Tower,burstTower,aoeTower;
    private List<BaseTower> towerInRange = new List<BaseTower>();


    public int currentCardinTower = 0;

    public static bool knightOn;

    public bool isDiamondGem = false;
    public bool isRubyGem = false;
    public bool isSaphhireGem = false;

    public bool getBonusFromRuby = false;
    public bool getBonusFromSapphire= false;
    public bool getBonusFromEmerald = false;
    public bool getBonusFromDiamond = false;

    void Start()
    {
       
        towerInput = TowerInput.instance;
        rs = Resercher.instance;
        uiTower = GameObject.Find("TowerUI");
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        Stack<GameObject> nearestEnemys = new Stack<GameObject>(3);



        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }


        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    public void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            if (knightOn == true)
            {
                bonusAttack = (bullet.attackDamage / 100) * 10;
                bullet.attackDamage += bonusAttack;
            }
            else
            {
                bonusAttack = 0;
            }
            if (isFire == true)
            {
                if (target.name == "Undead(Clone)")
                {
                    bullet.attackDamage += 30 + bonusAttack;
                }
            } else if (isFire2 == true)
            {
                if(target.name == "Undead(Clone)")
                {
                    bullet.attackDamage += 40 + bonusAttack;
                }
            } else if (isFire3 == true)
            {
                if (target.name == "Undead(Clone)")
                {
                    bullet.attackDamage += 50 + bonusAttack;
                }
            }
            else if (isAcid == true)
            {
                if (target.name == "Mech(Clone)")
                {
                    bullet.attackDamage += 30 + bonusAttack;
                }
            } else if (isAcid2 == true)
            {
                if (target.name == "Mech(Clone)")
                {
                    bullet.attackDamage += 40 + bonusAttack;
                }
            } else if(isAcid3 == true)
            {
                if (target.name == "Mech(Clone)")
                {
                    bullet.attackDamage += 50 + bonusAttack;
                }
            }
            else if (isBurst == true)
            {
                if (target.name == "Undead(Clone)")
                {
                    bullet.attackDamage += 30 + bonusAttack;
                }
            }
            else if(isBurst2 == true)
            {
                if (target.name == "Undead(Clone)")
                {
                    bullet.attackDamage += 40 + bonusAttack;
                }
            }
            else if(isBurst3 == true)
            {
                if (target.name == "Undead(Clone)")
                {
                    bullet.attackDamage += 50+ bonusAttack;
                }
            }
            else if (isElec == true)
            {
                if (target.name == "Mech(Clone)")
                {
                    bullet.attackDamage += 30 + bonusAttack;
                }
            }else if(isElec2 == true)
            {
                if (target.name == "Mech(Clone)")
                {
                    bullet.attackDamage += 40 + bonusAttack;
                }
            }
            else if(isElec3 == true)
            {
                if (target.name == "Mech(Clone)")
                {
                    bullet.attackDamage += 50+ bonusAttack;
                }
            }
            else if(isPoison == true)
            {
                if (target.name == "Demi-humen(Clone)")
                {
                    bullet.attackDamage += 30+ bonusAttack;
                }
            }
            else if(isPoison2 == true)
            {
                if (target.name == "Demi-humen(Clone)")
                {
                    bullet.attackDamage += 40+ bonusAttack;
                }
            }
            else if(isPoison3 == true)
            {
                if (target.name == "Demi-humen(Clone)")
                {
                    bullet.attackDamage += 50+ bonusAttack;
                }
            }
            else
            {

            }
            if(isDiamondGem == true)
            {
                bullet.bonusExplodRadius = 20;
            }
            else
            {

            }
            if(isSaphhireGem == true)
            {
                bullet.bonusAoeTime = 3;
            }
            else
            {

            }
            bullet.Seek(target);

        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }


    // Update is called once per frame
    void Update()
    {

        if (target != null && isAura == false)
        {
            LockOnTarget();
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
        if(isAura == true)
        {
            AuraAplly();
           
        }
    


        checkLvl();


    }
    public void checkLvl()
    {
        //base Tower
        if (rs.currentNormalLevel == 1)
        {
          
        }
        else if (rs.currentNormalLevel == 2)
        {
            lvl2BaseTower = true;
        }
        else if (rs.currentNormalLevel == 3)
        {
            lvl3BaseTower = true;
        }
        else if (rs.currentNormalLevel == 4)
        {
            lvlBaseMax = true;
        }
        else
        {

        }

        //Burst Tower
        if (rs.currentBurstLevel == 2)
        {
            lvl2BurstTower = true;
        }
        if (rs.currentBurstLevel == 3)
        {
            lvl3BurstTower = true;
        }
        if (rs.currentBurstLevel == 4)
        {
            lvlBurstMax = true;
        }

        //Aoe Tower
        if (rs.currentAOELevel == 2)
        {
            lvl2Aoe = true;
        }
        if (rs.currentAOELevel == 3)
        {
            lvl3Aoe = true;
        }
        if (rs.currentAOELevel == 4)
        {
            lvlMaxAoe = true;
        }
    }

    public void AuraAplly()
    {
        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, range, Tower);
        foreach(Collider hit in hitcolliders)
        {
            BaseTower tower = hit.gameObject.GetComponent<BaseTower>();
            if(tower != null && !towerInRange.Contains(tower))
            {
                towerInRange.Add(tower);
            }
        }
        for(int i = towerInRange.Count - 1; i >= 0; i--)
        {
            BaseTower tower2 = towerInRange[i];
            if(tower2 == null || Vector3.Distance(transform.position,tower2.transform.position) > range)
            {
                towerInRange.RemoveAt(i);
            }
            
        }
        Collider[] hitcolliders2 = Physics.OverlapSphere(transform.position, range, aoeTower);
        foreach (Collider hit in hitcolliders2)
        {
            BaseTower tower3 = hit.gameObject.GetComponent<BaseTower>();
            if (tower3 != null && !towerInRange.Contains(tower3))
            {
                towerInRange.Add(tower3);
            }
        }
        for (int i = towerInRange.Count - 1; i >= 0; i--)
        {
            BaseTower tower = towerInRange[i];
            if (tower == null || Vector3.Distance(transform.position, tower.transform.position) > range)
            {
                towerInRange.RemoveAt(i);
            }

        }
        Collider[] hitcolliders3 = Physics.OverlapSphere(transform.position, range, burstTower);
        foreach (Collider hit in hitcolliders3)
        {
            BaseTower tower = hit.gameObject.GetComponent<BaseTower>();
            if (tower != null && !towerInRange.Contains(tower))
            {
                towerInRange.Add(tower);
            }
        }
        for (int i = towerInRange.Count - 1; i >= 0; i--)
        {
            BaseTower tower = towerInRange[i];
            if (tower == null || Vector3.Distance(transform.position, tower.transform.position) > range)
            {
                towerInRange.RemoveAt(i);
            }

        }

        foreach (BaseTower tower in towerInRange)
        {
            if (isFire == true)
            {
                if (tower.isFire == false)
                {
                    tower.isFire = true;
                }
                else
                {

                }
            }else if (isFire2 == true)
            {
                if(tower.isFire2 == false)
                {
                    tower.isFire2 = true;
                }
                else
                {

                }
            }else if(isFire3 == true)
            {
                if (tower.isFire3 == false)
                {
                    tower.isFire3 = true;
                }
                else
                {

                }
            }else if(isAcid == true)
            {
                if (tower.isAcid == false)
                {
                    tower.isAcid = true;
                }
                else
                {

                }
            }else if(isAcid2 == true)
            {
                if(tower.isAcid2 == false)
                {
                    tower.isAcid2 = true;
                }
                else
                {

                }
            }else if(isAcid3 == true)
            {
                if(tower.isAcid3 == false)
                {
                    tower.isAcid3 = true;
                }
                else
                {

                }
            }else if(isPoison == true)
            {
                if (tower.isPoison == false)
                {
                    tower.isPoison = true;
                }
                else
                {

                }
            }else if(isPoison2 == true)
            {
                if(tower.isPoison2 == false)
                {
                    tower.isPoison2 = true;
                }
                else
                {

                }
            }else if(isPoison3 == true)
            {
                if(tower.isPoison3 == false)
                {
                    tower.isPoison3 = true;
                }
                else
                {

                }
            }else if(isElec == true)
            {
                if(tower.isElec == false)
                {
                    tower.isElec = true;
                }
                else
                {

                }
            }else if(isElec2 == true)
            {
                if(tower.isElec2 == false)
                {
                    tower.isElec2 = true;
                }
                else
                {

                }
            }else if(isElec3 == true)
            {
                if (tower.isElec3 == false)
                {
                    tower.isElec3 = true;
                }
                else
                {

                }
            }else if(isBurst == true)
            {
                if(tower.isBurst == false)
                {
                    tower.isBurst = true;
                }
                else
                {

                }
            }else if(isBurst2 == true)
            {
                if(tower.isBurst2 == false)
                {
                    tower.isBurst2 = true;
                }
                else
                {

                }
            }else if(isBurst3 == true)
            {
                if(tower.isBurst3 == false)
                {
                    tower.isBurst3 = true;
                }
                else
                {

                }
            }
            else
            {

            }
        }
    }

    public void OnMouseDown()
    {
        uiTower.transform.position = new Vector3(960, 540, 0);
        towerInput.SelectTowerTarget(this);
        towerInput.SetObjectTower(this.gameObject);
       
    }
}
