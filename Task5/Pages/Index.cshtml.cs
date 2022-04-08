using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task5.Entites;
using Task5.Services;

namespace Task5.Pages
{
    public class IndexModel : PageModel
    {
        private IRepository<Student> _repository;

        public IndexModel(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public List<Student> Students { get; set; }

        [BindProperty]
        public Student Student { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        public void OnGet()
        {
            Students = string.IsNullOrEmpty(Search)
                ? _repository.GetAll()
                : _repository.GetAll().Where(st => st.Name.Contains(Search)).ToList();
        }

        public IActionResult OnPost()
        {
            try
            {
                _repository.Add(Student);
            }
            catch (Exception){}
            return RedirectToAction("index");
        }

        public void OnGetDeleteStudent(int id)
        {
            _repository.Delete(_repository.Get(id));
            Students = string.IsNullOrEmpty(Search)
                ? _repository.GetAll()
                : _repository.GetAll().Where(st => st.Name.Contains(Search)).ToList();
        }
    }
}