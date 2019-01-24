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

        private ValueSpace[] _observationSpace;
        public ValueSpace[] ObservationSpace => _observationSpace;

        protected override void PreSetup()
        {
            base.PreSetup();

            _observationSpace = new ValueSpace[wallStates.Count];
            for(int i = 0; i < _observationSpace.Length; i++)
            {
                _observationSpace[i] = new ValueSpace()
                {
                    _Max_Value = 1,
                    _Min_Value = 0,
                    _Decimal_Granularity = 0
                };
            }
        }

        public override void UpdateObservation() { FloatEnumerable = wallStates; }
        //public override IEnumerable<float> FloatEnumerable()
        //{
        //    return wallStates;
        //}


    }
}