using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using IdCore.Data;

namespace IdCore.Extension
{
    public class SMSClaimsTransformer : IClaimsTransformer
    {
        protected readonly ApplicationDbContext db;

        public SMSClaimsTransformer()
        {   
        }

        public SMSClaimsTransformer(ApplicationDbContext context)
        {
            db = context;
        }

        
        public Task<ClaimsPrincipal> TransformAsync(ClaimsTransformationContext context)
        {
            var identity = (ClaimsIdentity)context.Principal.Identity;

            if (context.Context.User != null)
            {
                var userClaims = db.UserClaims.Where(x => x.UserId == context.Context.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                foreach (var claim in db.UserClaims)
                {
                    if (identity.HasClaim(claim.ClaimType, claim.ClaimValue))
                    {
                        identity.AddClaim(new Claim(claim.ClaimType, claim.ClaimValue));
                    }

                }
            }
            return Task.FromResult(context.Principal);
        }
    }
}
