using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task5.Entites;
using Task5.Services;

namespace Task5.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IRepository<Student> _repository;

        public DetailsModel(IRepository<Student> repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Student Student { get; set; }
        public void OnGet(int id)
        {
            Student = _repository.Get(id);
        }
    }
}