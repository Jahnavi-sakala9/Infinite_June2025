using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public delegate void RingEventHandler();
    class MobilePhone
    {
        public event RingEventHandler OnRing;
        public void ReceiveCall()
        {
            Console.WriteLine("Incoming call....");
            OnRing.Invoke();
        }
    }
    class RingtonePlayer
    {
        public void OnPhoneRing()
        {
            Console.WriteLine("Playing Ringtone");
        }
    }
    class ScreenDisplay
    {
        public void OnPhoneRing()
        {
            Console.WriteLine("Displaying caller Information");
        }
    }
    class VibrationMotor
    {
        public void OnPhoneRing()
        {
            Console.WriteLine("Phone is Vibrating");
        }
    }
    class HandlingMobilePhone {
        public static void Main()
        {
            MobilePhone phone = new MobilePhone();
            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay display = new ScreenDisplay();
            VibrationMotor vibration = new VibrationMotor();

            phone.OnRing += ringtone.OnPhoneRing;
            phone.OnRing += display.OnPhoneRing;
            phone.OnRing += vibration.OnPhoneRing;
            phone.ReceiveCall();
            Console.Read();
        }
    }
}
