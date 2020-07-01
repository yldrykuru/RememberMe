using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RememberMe.Data
{
    public class RememberMeController : Controller
    {
        protected readonly ApplicationDbContext _context;
        public RememberMeController(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}