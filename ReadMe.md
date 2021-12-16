# Mazdi.Validators
## Server Side Validations Made Easy



Mazdi.Validators is an effort to help reduce manual validations duplicate code and checks on server side especially for Rest API. This is very first version of the Nuget and further development is going to make it more easy to use.

## Usage

Initialize a List of Validation Model
```cs
 var toBeValidated = new List<ValidationModel>();
```
Let's Take an Example of Student class.
```cs
 var student = new Student()
            {
                Name = "AnakinSkywalker",
                Email = "skywalker@master.com",
                Age = 5,
                Fee = 300.00M,
                RollNo = "24A"
            };
```
Now Add Properties to list "toBeValidated"
```cs
  toBeValidated.Add(new ValidationModel()
            {
                PropertyValue = student.Name,
                ValidationType = ValidationType.Name 
                Maximum = 5,
                Minimum = 2,
                PropertyName = "First Name"
            });
            
  toBeValidated.Add(new ValidationModel()
            {
                PropertyValue = student.Age,
                ValidationType = ValidationType.Age 
                Minimum = 11,
                PropertyName = nameof(student.Age)
            });
```
Call Method 

```cs
var validationResult = ValidationService.Validate(toBeValidated);
```
if Validation is Successfull, it returns 
1. Status Code will be 200;
2. Messages List would be empty

if Validations fails,
1. Status Code will be 400;
2. There will be list of Messages depending upon the number of failed validations. e.g 
"Name Maximum Length should be 5 characters."
"Minimum Age should be 11"


## Mazdi.Validator
```cs
    public class ValidationModel
    {
        public string PropertyName { get; set; }
        public object PropertyValue { get; set; }
        public ValidationType ValidationType { get; set; }
        public int? Maximum { get; set; }
        public int? Minimum { get; set; }
        public string Format { get; set; }
        public string CustomMessage { get; set; }
        public int? DecimalPlaceLimit { get; set; }
    }
```
## _PropertyValue_ (object)
Holds the value of property

## _PropertyName_ (string)
Holds the name of Property. You can use nameof() OR provide the name as well

## _ValidationType_ (enum)
Current Available Validation Types are
1. Email
2. Name
3. Title
4. Address
5. GeneralString 
6. Age
7. Numerics

GeneralString: it could be any general string like address, blood group, favourte color, You name it.

Numerics: Could be decimal/float/double/integers.

## _Maximum_ (nullable int)
It is used to validate maximum length/size of string or integer. By default it is null, if provided a value then it will be considered for validation.

## _Minimum_ (nullable int)
It is used to validate minimum length/size of string or integer. By default it is null, if provided a value then it will be considered for validation.

## _Format_ (string)
It holds the masking and matches the provided mask with the property value. for example Format could be "xxx_xxxxx_xxx".

## _CustomMessage_ (string)
It is used to return the custom error message for the specific property instead of system generated error message upon failed validation.

## _DecimalPlaceLimit_ (integer)
It is a nullable integer, if value is provided then it will be considered for validation. it is used to verify the decimal places for decimal/double/float values.