using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace blog6WebApp.Pages
{
    public class UsersModel : PageModel
    {
        private readonly ILogger<UsersModel> _logger;

        private readonly ICosmosDbService _cosmosDbService;

        public List<User> Users { get; set; }

        public UsersModel(ICosmosDbService cosmosDbService, ILogger<UsersModel> logger)
        {
            _logger = logger;
            _cosmosDbService = cosmosDbService;
        }

        public async Task OnGetAsync()
        {
            Users = (await _cosmosDbService.GetUsersAsync()).ToList();
        }
    }
}
