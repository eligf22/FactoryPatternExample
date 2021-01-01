using System;

namespace FactoryPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectFactory objFactory = new ObjectFactory();
            
            var seller = objFactory.Get(ObjectType.Seller);
            Console.WriteLine(seller.GetInfo());
            var product = objFactory.Get(ObjectType.Product);
            Console.WriteLine(product.GetInfo());
            
        }
    }

    public enum ObjectType
    {
        Seller,
        Product
    }
    public class ObjectFactory
    {
        private ObjectType _type;
        public IObject Get(ObjectType type)
        {
            _type = type;
            return GetObject();           
        }

        private IObject GetObject()
        {
            IObject obj;

            switch (_type)
            {
                case ObjectType.Seller:
                    return obj = new Seller() {ShopName = "TheDogFace", Email = "sales@thedogface.com", PhoneNumber = "34677657783"};
                case ObjectType.Product:
                    return obj = new Product() {Name = "dogFood", BrandName = "Akana", Sku = "123"};
                default:
                    throw new Exception("Not able to generate an object type");
                   
            }
        }
    }
    public interface IObject
    {
        string GetInfo();
    }

    public class Seller : IObject
    {
        public string ShopName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string GetInfo()
        {
            return string.Format("Seller ShopName is {0}. Email is {1}.  PhoneNumber is {2}", ShopName, Email, PhoneNumber);
        }
    }

    public class Product : IObject
    {
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string Sku { get; set; }

        public string GetInfo()
        {
            return string.Format("Product name is {0}. BrandName is {1}.  Sku is {2}", Name, BrandName, Sku);
        }
    }
}
