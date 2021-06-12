using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wine : Food
{//INHERITANCE

    protected override void Consume()//POLYMORPHISM
    {
        fatMan.WineCount += 1;
        base.Consume();
        if(fatMan.WineCount > 6)
        {
            fatMan.PassOutDrunk();
            mainUIHandler.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        mainUIHandler.PrintMessage(this);//Static methods are considered bad OOP practice, so use an object reference instead. Delegates are normally the best route, but not really relevant for this case.
        Consume();
    }
}
