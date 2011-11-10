using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public class TrackArcRight : Track
    {
        float radius;
        float angle;

        float lengthRight;
        float lengthLeft;


        public TrackArcRight(float radius, float angle, float speed, float acceleration)
            : base()
        {
            this.acceleration = acceleration;
            this.angle = angle;
            this.radius = radius;
            this.nominalSpeed = speed;

            this.length = (float)((2.0f * radius * Math.PI) / 360.0f) * angle;
            this.lengthRight =(float)((2.0f * (radius + Constants.HalfAxleLength) * Math.PI) / 360.0f) * angle;
            this.lengthLeft = (float)((2.0f * (radius - Constants.HalfAxleLength) * Math.PI) / 360.0f) * angle;
        }

        public override void IncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed)
        {
            leftSpeed = -(newVelocity * (this.lengthRight / this.length));
            rightSpeed =  (newVelocity * (this.lengthLeft / this.length));

            if (Math.Abs(leftSpeed) > Constants.maxSpeed || Math.Abs(rightSpeed) > Constants.maxSpeed)
            {
                throw new ArgumentException("Speed of any of the motors cannot be greater " + Constants.maxSpeed.ToString());
            }

            currentVelocity = newVelocity;
            DoStep(timeInterval);
        }
    }
}
