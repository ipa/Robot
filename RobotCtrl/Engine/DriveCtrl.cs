//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: DriveCtrl.cs 735 2011-10-13 09:16:14Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{ 

    public abstract class DriveCtrl : IDisposable
    {

        #region constructor & destructor
        /// <summary>
        /// Initialisiert den Motorencontroller.
        /// </summary>
        public DriveCtrl() {}


        /// <summary>
        /// Dispose Methode wird in der abstrakten Klasse nicht gebraucht, kann aber überschrieben werden.
        /// </summary>
        public virtual void Dispose() { }
        #endregion


        #region properties
        /// <summary>
        /// Schaltet die Stromversorgung der beiden Motoren ein oder aus.
        /// </summary>
        public bool Power
        {
            set { DriveState = (value) ? DriveState | 0x03 : DriveState & ~0x03; }
        }


        /// <summary>
        /// Liefert den Status ob der rechte Motor ein-/ausgeschaltet ist bzw. schaltet den rechten Motor ein-/aus.
        /// </summary>
        public bool PowerRight
        {
            get { return (DriveState & 0x01) != 0; }
            set { DriveState = (value) ? DriveState | 0x01 : DriveState & ~0x01; }
        }


        /// <summary>
        /// Liefert den Status ob der linke Motor ein-/ausgeschaltet ist bzw. schaltet den linken Motor ein-/aus.
        /// </summary>
        public bool PowerLeft
        {
            get { return (DriveState & 0x02) != 0; }
            set { DriveState = (value) ? DriveState | 0x02 : DriveState & ~0x02; }
        }


        /// <summary>
        /// Bietet Zugriff auf das Status-/Controlregister
        /// </summary>
        public abstract int DriveState { get; protected set; }
        #endregion


        #region methods
        /// <summary>
        /// Setzt die Motorencontroller zurück.
        /// </summary>
        public abstract void Reset();
        #endregion


    }
}
