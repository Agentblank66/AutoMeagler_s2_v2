using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace AutoMeagler_s2_v2.Models
{
    [Table("Car")]
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        /// <summary>
        /// Properties of the Car class.
        /// </summary>
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string TypeOfCar { get; set; }
        [Required]
        [StringLength(40)]
        public string Brand { get; set; }
        [Required]
        [StringLength(40)]
        public string Model { get; set; }

        [Required]
        [StringLength(40)]

        public string Color { get; set; }
        [Required]
        [StringLength(40)]
        public string Fuel { get; set; }
        [Required]
        public int ModelYear { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        public double KmPrL { get; set; }
        [Required]
        public int TopSpeed { get; set; }
        [Required]
        public int Doors { get; set; }
        [Required]
        public int HorsePower { get; set; }
        [Required]
        [StringLength(20)]
        public string Gear { get; set; }
        [Required]
        public double MotorSize { get; set; }
        [Required]
        public int Cylinders { get; set; }
        [Required]
        public double ZeroToOneHundred { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public int NumOffWheels { get; set; }
        [Required]
        public double MaxPull { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public bool Status { get; set; }
        public int? PriceMonth { get; set; }
        public int? LeasingPeriod { get; set; }
        public int? KmIncluded { get; set; }
        public bool ForSale { get; set; }

        public ICollection<Image> Images { get; set; } = new List<Image>();


		/// <summary>
		/// Default constructor for the Car class.
		/// </summary>
		public Car(){ }

        /// <summary>
        /// Constructor for the Car class with parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="brand"></param>
        /// <param name="color"></param>
        /// <param name="fuel"></param>
        /// <param name="modelYear"></param>
        /// <param name="price"></param>
        /// <param name="mileage"></param>
        /// <param name="kmPrL"></param>
        /// <param name="topSpeed"></param>
        /// <param name="doors"></param>
        /// <param name="horsePower"></param>
        /// <param name="gear"></param>
        /// <param name="cylinders"></param>
        /// <param name="motorSize"></param>
        /// <param name="zeroToOneHundred"></param>
        /// <param name="length"></param>
        /// <param name="numOffWheels"></param>
        /// <param name="maxPull"></param>
        /// <param name="weight"></param>
        /// <param name="status"></param>
        /// <param name="priceMonth"></param>
        /// <param name="leasingPeriod"></param>
        /// <param name="KmIncluded"></param>
        /// 
         

        // Contructor til KØB BIL
        public Car(int id, string type, string brand, string model, string color, string fuel, int modelYear, int price, int mileage, double kmPrL, int topSpeed, int doors, int horsePower, string gear, int cylinders, double motorSize, double zeroToOneHundred, int length, int numOffWheels, double maxPull, int weight, bool status)
        {
            Id = id;
            TypeOfCar = type;
            Brand = brand;
            Model = model;
            Color = color;
            Price = price;
            Fuel = fuel;
            ModelYear = modelYear;
            Price = price;
            Mileage = mileage;
            KmPrL = kmPrL;
            TopSpeed = topSpeed;
            Doors = doors;
            HorsePower = horsePower;
            Gear = gear;
            Cylinders = cylinders;
            MotorSize = motorSize;
            ZeroToOneHundred = zeroToOneHundred;
            Length = length;
            NumOffWheels = numOffWheels;
            MaxPull = maxPull;
            Weight = weight;
            Status = status;

        }

        //Contructor til LEASING
        public Car(int id, string type, string brand, string model, string color, string fuel, int modelYear, int priceMonth, int mileage, double kmPrL, int topSpeed, int doors, int horsePower, string gear, int cylinders, double motorSize, double zeroToOneHundred, int length, int numOffWheels, double maxPull, int weight, int leasingPeriod, int kmIncluded)
        {
            Id = id;
            TypeOfCar = type;
            Brand = brand;
            Model = model;
            Color = color;
            PriceMonth = priceMonth;
            Fuel = fuel;
            ModelYear = modelYear;
            Mileage = mileage;
            KmPrL = kmPrL;
            TopSpeed = topSpeed;
            Doors = doors;
            HorsePower = horsePower;
            Gear = gear;
            Cylinders = cylinders;
            MotorSize = motorSize;
            ZeroToOneHundred = zeroToOneHundred;
            Length = length;
            NumOffWheels = numOffWheels;
            MaxPull = maxPull;
            Weight = weight;
            LeasingPeriod = leasingPeriod;
            KmIncluded = kmIncluded;
        }

        /// <summary>
        /// Overrides the ToString method to provide a string representation of the Car object.
        /// </summary>
        /// <returns> A string with properties </returns>
        public override string ToString()
        {
            return $"Id: {Id} Type: {TypeOfCar} Brand: {Brand} Color: {Color} Fuel: {Fuel} ModelYear: {ModelYear} Price: {Price} Mileage: {Mileage} KmPrL: {KmPrL} TopSpeed: {TopSpeed} Doors: {Doors} HorsePower: {HorsePower} Gear: {Gear} Cylinders: {Cylinders} MotorSize: {MotorSize} ZeroToOnehundred: {ZeroToOneHundred} Length: {Length} NumOffWheels: {NumOffWheels} MaxPull: {MaxPull} Weight: {Weight} Status: {Status} PriceMonth: {PriceMonth} LeasingPeriod: {LeasingPeriod} KmIncluded: {KmIncluded}";
        }
    }
}
