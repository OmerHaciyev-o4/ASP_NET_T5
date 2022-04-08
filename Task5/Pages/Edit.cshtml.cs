using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task5.Entites;
using Task5.Services;

namespace Task5.Pages
{
    public class EditModel : PageModel
    {
        public static int ID { get; set; }
        private readonly IRepository<Student> _repository;
        public EditModel(IRepository<Student> repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Student Student { get; set; }
        
        public void OnGet(int id)
        {
            ID = id;
            Student = _repository.Get(id);
        }

        public IActionResult OnPost()
        {
            Student.Id = ID;
            _repository.Update(Student);
            return RedirectToPage("index");
        }
    }
}