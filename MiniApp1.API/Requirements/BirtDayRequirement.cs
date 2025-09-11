using Microsoft.AspNetCore.Authorization;

namespace MiniApp1.API.Requirements;

public class BirtDayRequirement : IAuthorizationRequirement
{
    public int Age { get; set; }

    public BirtDayRequirement(int age)
    {
        Age = age;
    }


    public class BirtDayRequirementHandler : AuthorizationHandler<BirtDayRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BirtDayRequirement requirement)
        {
            var birthDate = context.User.FindFirst("birthday");

            if(birthDate == null) 
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var today = DateTime.Now;

            var age = today.Year - Convert.ToDateTime(birthDate.Value).Year;


            if(age >= requirement.Age) 
            {
                context.Succeed(requirement);
            }
            else 
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }

}
