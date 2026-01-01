
using System.Device.Gpio;
using System.Device.Gpio.Drivers;

namespace Petsephoner
{
    public class Feeder
    {
        public static Feeder Instance = new Feeder();
        
        private GpioController _controller;
        private const int ledPin = 18;

        public Feeder()
        {
            _controller = new GpioController(new RaspberryPi3Driver());

            _controller.OpenPin(ledPin, PinMode.Output);

            _controller.Write(ledPin, PinValue.Low);
        }

        public async Task SetLed(bool value)
        {
            _controller.Write(ledPin, value ? PinValue.High : PinValue.Low);
        }
    }
}
