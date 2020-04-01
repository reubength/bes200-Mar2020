using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class OnCallDeveloperController : Controller
    {
        ILookupOnCallDevelopers onCallLookup;

        public OnCallDeveloperController(ILookupOnCallDevelopers onCallLookup)
        {
            this.onCallLookup = onCallLookup;
        }

        [HttpGet("OnCallDeveloper")]
        public async Task<ActionResult> GetOnCallDeveloper()
        {
            OnCallDeveloperResponse response = await onCallLookup.GetOnCallDeveloper();
            
            return Ok(response);
        }
    }
}
