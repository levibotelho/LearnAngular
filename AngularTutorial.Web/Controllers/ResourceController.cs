using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularTutorial.Web.Controllers
{
    public class ResourceController : Controller
    {
        [HttpGet]
        JsonResult Notes()
        {
            return Json(GetNoteList());
        }

        [HttpGet]
        JsonResult Notes(int id)
        {
            return Json(GetNoteList().FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        void Notes(Note note)
        {
            var noteList = GetNoteList();
            var existingNote = noteList.FirstOrDefault(x => x.Id == note.Id);
            if (existingNote != null)
                existingNote.Text = note.Text;
            else
                noteList.Add(note);
        }

        List<Note> GetNoteList()
        {
            var taskList = Session["TaskList"];
            if (taskList == null)
                Session["TaskList"] = taskList = new List<Note>();
            return (List<Note>)taskList;
        }

        class Note
        {
            public int Id { get; set; }
            public string Text { get; set; }
        }
    }
}