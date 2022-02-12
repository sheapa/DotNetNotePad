using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotePad.Models;

namespace NotePad.Pages
{
    public class IndexModel : PageModel
    {
        private readonly INoteData _noteData;

        
        //[BindProperty(SupportsGet = true)]
        //public int Id { get; set; }


        [BindProperty]
        public NoteUpdateModel UpdateModel { get; set; }


        public List<NoteModel> Note { get; set; }


        public IndexModel(INoteData noteData)
        {
            _noteData = noteData;
            
        }


        public async Task OnGet()
        {
            Note = await _noteData.All();
        }

        public void Retrive()
        {
            throw new NotImplementedException();
        }



        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            await _noteData.UpdateNote(UpdateModel.Id, UpdateModel.Description);
            return RedirectToPage("./Index", new { UpdateModel.Id });
        }




    }
}