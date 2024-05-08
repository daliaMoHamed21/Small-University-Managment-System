using System.ComponentModel.DataAnnotations;

namespace MVC_Day3.CustomValidationRoles
{
    public class DividedByTwoValidation:ValidationAttribute
    {
        int z;
        public DividedByTwoValidation(int x=2)
        {
            z = x;
            
        }
        public override bool IsValid(object? value)
        {
            int x = (int)value;
            if (x % z == 0)
            {
                return true;
            }
            else
                return false;

            return base.IsValid(value);
        }
    }
}
