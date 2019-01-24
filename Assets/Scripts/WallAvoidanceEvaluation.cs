using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using droid.Runtime.Utilities.Misc;
using droid.Runtime.Utilities.Sensors;

namespace droid.Runtime.Prototyping.Evaluation
{
    public class WallAvoidanceEvaluation : ObjectiveFunction
    {
        private bool collided;
        private bool success;
        [SerializeField] GameObject player;
        protected override void PostSetup()
        {
            if (player)
            {
                NeodroidUtilities.RegisterCollisionTriggerCallbacksOnChildren<ChildCollider2DSensor, Collider2D, Collision2D>(
                    this,
                    player.transform,
                    on_trigger_enter_child: OnWallCollision
                );
            }
        }

        private void OnWallCollision(GameObject child_sensor_game_object, Collider2D collider)
        {
            if (child_sensor_game_object.layer == LayerMask.NameToLayer("Player"))
            {
                if (collider.GetComponent<MeshRenderer>().enabled)
                {
                    collided = true;
                }
                else
                {
                    success = true;
                }
            }
        }

        public override float InternalEvaluate()
        {

            if (collided)
            {
                Debug.Log("Hwllpo");
                ParentEnvironment.Terminate("Died");

                Debug.Log("Hwllpo diesd");
                return -1;
            }

            if (success)
            {
                Debug.Log("Success!");
                return 1;
            }
            return 0;
        }
        public override void InternalReset() { collided = false; success = false; }
    }
}
