using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public CreateModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentVM StudentVM { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyStudent = new Student();

            //使用TryUpdateModelAsync()更新部分数据
            //if (await TryUpdateModelAsync<Student>(
            //    emptyStudent,
            //    "student",   // Prefix for form value.
            //    s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            //{
            //    _context.Students.Add(emptyStudent);
            //    await _context.SaveChangesAsync();
            //    return RedirectToPage("./Index");
            //}

            //更好的方式使用视图模型
            var entry = _context.Add(emptyStudent);
            entry.CurrentValues.SetValues(StudentVM);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
