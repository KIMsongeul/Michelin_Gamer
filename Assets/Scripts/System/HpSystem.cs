using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSystem : MonoBehaviour
{
    public float curHp;
    public float maxHp;

    public Slider HpBarSlider;

    public void Damage(float damage)   
    {
        if (maxHp == 0 || curHp <= 0)
        {
            return;
        }

        curHp -= damage;
        CheckHp();
    }
    
    
    public void CheckHp()
    {
        if ( (HpBarSlider != null))
        {
            HpBarSlider.value = curHp / maxHp;
        }
    }
    
    public void SetHp(float amount)
    {
        maxHp = amount;
        curHp = maxHp;
    }
    
}
