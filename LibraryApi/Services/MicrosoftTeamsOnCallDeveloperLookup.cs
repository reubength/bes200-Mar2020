using LibraryApi.Controllers;
using LibraryApi.Models;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public class MicrosoftTeamsOnCallDeveloperLookup : ILookupOnCallDevelopers
    {
        IDistributedCache Cache;
        public MicrosoftTeamsOnCallDeveloperLookup(IDistributedCache cache)
        {
            Cache = cache;
        }
        public async Task<OnCallDeveloperResponse> GetOnCallDeveloper()
        {
            var email = await Cache.GetAsync("email");
            string emailAddress = null; 
            if(emailAddress == null)
            {
                //call the Micrsoft Teams api get the emai address and add to cache
                var emailToSave = $"Bob-{DateTime.Now.ToLongTimeString()}@aol.com";
                var encodedEmail = Encoding.UTF8.GetBytes(emailToSave);
                var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddSeconds(15));

                await Cache.SetAsync("email",encodedEmail, options);

                emailAddress = emailToSave;

            }else
            {
                emailAddress = Encoding.UTF8.GetString(email);
            }

            return new OnCallDeveloperResponse { Email = emailAddress };
        }
    }
}
