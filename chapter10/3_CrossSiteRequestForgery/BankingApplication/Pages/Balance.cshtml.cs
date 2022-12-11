﻿using System;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankingApplication.Pages
{
    // Уберите этот атрибут для зашиты от атак CSRF
    [IgnoreAntiforgeryToken]
    [Authorize]
    public class BalanceModel : PageModel
    {
        private static ConcurrentDictionary<string, int> _balances = new ConcurrentDictionary<string, int>();

        public int Balance { get; set; }

        public void OnGet()
        {
            var userId = User.Identity.Name;

            Balance = GetBalance(userId);
        }

        public IActionResult OnPost(int amount)
        {
            if (amount <= 0)
            {
                return BadRequest();
            }

            var userId = User.Identity.Name;
            var balance = GetBalance(userId);
            _balances[userId] = balance - amount;

            return RedirectToPage("/Balance");
        }

        private static int GetBalance(string userId)
        {
            return _balances.GetOrAdd(userId, 10_000);
        }
    }
}
