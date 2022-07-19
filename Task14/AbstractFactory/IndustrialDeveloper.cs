using Products.Task14.Enums;
using Products.Task14.Products;
using Task14.Enums;
using Task14.Interfaces;
using Task14.Products.Industrial;

namespace Task14.AbstractFactory
{
    internal class IndustrialDeveloper : AbstractFactoryDev
    {
        //public static event StorageTermHandler StorageTermHandlerEvent;
        private string _name;
        private decimal _price;
        private int _weight;
        private double _volume;
        private bool _isCorosion;
        private IronType? Type;
        private FractionStone? Fraction;
        private WoodGrade? Grade;

        public override string Name
        {
            get => _name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    _name = value;
                }
            }
        }
        public override decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value));
                }
                else
                {
                    _price = value;
                }
            }
        }
        public override int Weight
        {
            get => _weight;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value));
                }
                else
                {
                    _weight = value;
                }
            }
        }

        public IndustrialDeveloper(string name, decimal price, double volume, FractionStone? fraction, bool isСorrosion = false)
        {
            _name = name;
            _price = price;
            _volume = volume;
            Fraction = fraction;
            _isCorosion = isСorrosion;
        }

        public IndustrialDeveloper(string name, decimal price, double volume, IronType? type)
        {
            _name = name;
            _price = price;
            _volume = volume;
            Type = type;
        }

        public IndustrialDeveloper(string name, decimal price, int weight, WoodGrade? grade)
        {
            _name = name;
            _price = price;
            _weight = weight;
            Grade = grade;
        }

        public override IProduct CreateCategoryProduct() => new Stone(_name, _price, _volume, Fraction);

        public override IProduct CreateDairyProduct() => new Iron(_name, _price, _volume, Type, _isCorosion);

        public override IProduct CreateWeightProduct() => new Wood(_name, _price, _weight, Grade);
    }
}
