namespace MostZadanie2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IInputInterface usbInterface = new USBInputInterface();
            IInputInterface bluetoothInterface = new BluetoothInputInterface();

            InputDevice keyboardUSB = new Keyboard(usbInterface);
            InputDevice mouseBluetooth = new Mouse(bluetoothInterface);

            keyboardUSB.Send("Hello from USB Keyboard!");
            mouseBluetooth.Send("Hello from Bluetooth Mouse!");
        }
    }

    interface IInputInterface
    {
        void SendInput(string input);
    }

    class USBInputInterface : IInputInterface
    {
        public void SendInput(string input)
        {
            Console.WriteLine($"Sending '{input}' via USB interface.");
        }
    }

    class BluetoothInputInterface : IInputInterface
    {
        public void SendInput(string input)
        {
            Console.WriteLine($"Sending '{input}' via Bluetooth interface.");
        }
    }

    abstract class InputDevice
    {
        protected IInputInterface inputInterface;

        public InputDevice(IInputInterface inputInterface)
        {
            this.inputInterface = inputInterface;
        }

        public abstract void Send(string input);
    }

    class Keyboard : InputDevice
    {
        public Keyboard(IInputInterface inputInterface) : base(inputInterface) { }

        public override void Send(string input)
        {
            Console.WriteLine("Keyboard input:");
            inputInterface.SendInput(input);
        }
    }

    class Mouse : InputDevice
    {
        public Mouse(IInputInterface inputInterface) : base(inputInterface) { }

        public override void Send(string input)
        {
            Console.WriteLine("Mouse input:");
            inputInterface.SendInput(input);
        }
    }
}
