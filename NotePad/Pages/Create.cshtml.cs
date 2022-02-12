using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace NotePad.Pages
{
    public class CreateModel : PageModel
    {
        private readonly INoteData _noteData;

         // bind = can write to on post
        [BindProperty]
        public NoteModel Note { get; set; }

        public CreateModel(INoteData noteData)
        {
            _noteData = noteData;
        }

        public void OnGet()
        {
            //_noteData.GetNoteById(Note.Count);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            int id = await _noteData.CreateNote(Note);

            return RedirectToPage("./Index", new { Id = id});
        }
    }
}
