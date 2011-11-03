using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public class TrackTurn : Track
    {
        public TrackTurn(float angle, float speed, float acceleration)
            : base()
        {
            this.acceleration = acceleration;
            this.nominalSpeed = speed;
            this.reverse = angle < 0.0f;

            this.length = Constants.LengthPerDegree * Math.Abs(angle);

        }

        public override void IncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed)
        {
            if (Math.Abs(newVelocity) > Constants.maxSpeed )
            {
                throw new ArgumentException("Speed of any of the motors cannot be greater " + Constants.maxSpeed.ToString());
            }

       
            leftSpeed = (!this.reverse) ? newVelocity : -newVelocity ;
            rightSpeed = (!this.reverse) ? newVelocity : -newVelocity;

            currentVelocity = newVelocity;
            DoStep(timeInterval);
        }
    }
}
