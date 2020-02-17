using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class ProfileModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "Введите данные";
        }
        public void OnPost(string name, int age)
        {
            Message = $"Имя: {name}  Возраст: {age}";
        }
    }
}