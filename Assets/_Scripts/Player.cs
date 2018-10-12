﻿using System;
using System.Collections;
using System.Collections.Generic;


public class Player //: ICombat
{

    public Inventory inventory;
    //    float hp;
    //    float maxHp;
    float oxygenLevel;
    private int _lifePoint;
    private int _armorPoint;
    private int _attackPoint;

    /*
     * can infer from oxygen level ...
    bool isDead;
     */

    List<PickUp> items;
    //    List<int> quests;
    float amountOfMoney;

    public Player()
    {
        oxygenLevel = 1.0f;
        inventory = new Inventory(10);
        setLifePoint(15);
        setArmorPoint(5);
        setAttackPoint(5);
        //	    hp = 10;
        //	    maxHp = 10;
        //      isDead = false;
    }



    void addItem(PickUp item)
    {
        items.Add(item);
    }

    void removeItem(PickUp item)
    {
        items.Remove(item);
    }

    
    public int getLifePoint()
    {
        return this._lifePoint;
    }

    public void setLifePoint(int value)
    {
        this._lifePoint = value;
    }

    public int getArmorPoint()
    {
        return this._armorPoint;
    }

    public void setArmorPoint(int value)
    {
        this._armorPoint = value;
    }

    public int getAttackPoint()
    {
        return this._attackPoint;
    }

    public void setAttackPoint(int value)
    {
        this._attackPoint = value;
    }

    public void receiveDommage(int amountDammage)
    {
        if (!amIDead())
        {
            if (getArmorPoint() > 0)
            {
                if (getArmorPoint() - amountDammage >= 0)
                {
                    setArmorPoint(getArmorPoint() - amountDammage);
                }
                else if (getArmorPoint() - amountDammage < 0)
                {
                    int lifePointLost = amountDammage - getArmorPoint();
                    setArmorPoint(0);
                    setLifePoint(getLifePoint() - lifePointLost);
                }
            }
            else
            {
                setLifePoint(getLifePoint() - amountDammage);
            }
        }
        else
        {
            //TODO
            //the monster is already dead
        }
    }

    public bool amIDead()
    {
        if (getLifePoint() > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void receiveHealth(int amountHealth)
    {
        if (!amIDead())
        {
            setLifePoint(getLifePoint() + amountHealth);
        }
        else
        {
            //TODO
            // i am already dead !
        }
    }
    
    public string getFeature()
    {
        string message = getArmorPoint() + " armor point , " + getLifePoint() + " hp, " + getAttackPoint() + " dammage point ";
        return message;
    }

    /*
    void addQuest(int questId)
    {
        quests.Add(questId);
    }

    void removeQuest(int questId)
    {
        quests.Remove(questId);
    }

    void earnMoney(float money)
    {
        amountOfMoney += money;
    }

    void looseMoney(float money)
    {
        amountOfMoney -= money;
    }
*/
}
