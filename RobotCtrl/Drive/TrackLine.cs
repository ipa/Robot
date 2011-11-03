using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public class TrackLine : Track
    {

        public TrackLine(float length, float speed, float acceleration) : base()
        {

            if (length < 0 || speed < 0) throw new ArgumentException("Parameters cannot be negative");


            this.length = length;
            this.acceleration = acceleration;
            this.nominalSpeed = speed;
       
        }

        public override void IncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed)
        {

            leftSpeed = -newVelocity;
            rightSpeed = newVelocity;

            if (Math.Abs(leftSpeed) > Constants.maxSpeed || Math.Abs(rightSpeed) > Constants.maxSpeed)
            {
                throw new ArgumentException("Speed of any of the motors cannot be greater " + Constants.maxSpeed.ToString());
            }

            currentVelocity = newVelocity;
            DoStep(timeInterval);
        }


      
    }
}
