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
        public List<User> Users { get; set; }

        public IndexModel(ICosmosDbService cosmosDbService, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _cosmosDbService = cosmosDbService;
        }

        public async Task OnGetAsync()
        {
            Users = (await _cosmosDbService.GetUsersAsync()).ToList();
        }

        public async Task OnPostAsync(string firstName, string lastName)
        {
            Users = (await _cosmosDbService.GetUsersAsync()).ToList();

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
