using System;
namespace TestMultitenantApi.Model
{
    public class Car
    {
        public Car()
        {
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Brand { get; set; } = default!;
    }
}

