using Mazdi.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazdiValidator
{
    public class MainService
    {
        public void Start()
        {
            var toBeValidated = new List<ValidationModel>();

            var student = new Student()
            {
                Name = "Anakin",
                Email = "skywalker@master.com",
                Age = 12,
                Fee = 300.00M,
                RollNo = "24A"
            };


            toBeValidated.Add(new ValidationModel()
            {
                PropertyValue = student.Name,
                ValidationType = ValidationType.Name,
                Maximum = 10,
                Minimum = 2,
                PropertyName = "Name"
            });

            toBeValidated.Add(new ValidationModel()
            {
                PropertyValue = student.Age,
                ValidationType = ValidationType.Age,
                Maximum = 15,
                Minimum = 5,
                PropertyName = nameof(student.Age)
            });

            toBeValidated.Add(new ValidationModel()
            {
                PropertyValue = student.Fee,
                ValidationType = ValidationType.Numerics,
                Minimum = 300,
                DecimalPlaceLimit = 1,
                PropertyName = "School Fee"
            });

            var result = ValidationService.Validate(toBeValidated);

        }
    }
}
