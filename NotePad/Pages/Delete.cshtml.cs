using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NotePad.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly INoteData _noteData;

        [BindProperty(SupportsGet = true)]

        public int Id { get; set; }

        public NoteModel Note { get; set; }

        public DeleteModel(INoteData noteData)
        {
            _noteData = noteData;
         
        }

         public async Task OnGet()
        {
            Note = await _noteData.GetNoteById(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            await _noteData.DeleteNote(Id);

            return RedirectToPage("./Index");
        }
    }
}
