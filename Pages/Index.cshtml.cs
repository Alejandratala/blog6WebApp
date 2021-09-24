using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace blog6WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICosmosDbService _cosmosDbService;

        public IndexModel(ICosmosDbService cosmosDbService, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _cosmosDbService = cosmosDbService;
        }

        public async Task OnGetAsync()
        {
        }

        public async Task OnPostAsync(string firstName, string lastName)
        {
            if (String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName)) {
                return;
            }

            Guid guid = Guid.NewGuid();

            var user = new User{
                Id = guid.ToString(),
                FirstName = firstName,
                LastName = lastName
            };

            await _cosmosDbService.AddUserAsync(user);
        }
    }
}
