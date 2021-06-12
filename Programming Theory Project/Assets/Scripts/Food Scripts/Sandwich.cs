using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandwich : Food
{//INHERITANCE

    protected override void Consume()//POLYMORPHISM
    {
        fatMan.SandwichCount += 1;
        base.Consume();
    }

    private void OnTriggerEnter(Collider other)
    {
        mainUIHandler.PrintMessage(this);//Static methods are considered bad OOP practice, so use an object reference instead. Delegates are normally the best route, but not really relevant for this case.
        Consume();
    }
}
