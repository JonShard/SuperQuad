using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using droid.Runtime.Interfaces;
using droid.Runtime.Utilities.Structs;


namespace droid.Runtime.Prototyping.Observers
{

    public class WallObserver : Observer,
                            IHasArray 
    {

        public List<float> wallStates = new List<float>();
        public float[] ObservationArray => wallStates.ToArray();
        public override void UpdateObservation() {  }

    }
}