using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CTC.Phonebook.Dto;


namespace CTC.Web.Models.Phonebook.ViewModel
{
    public class EditPersonModalViewModel
    {
        public PersonDto Person { get; set; }

        public List<SelectListItem> TipiContatto { get; set; }

        public EditPersonModalViewModel(List<SelectListItem> tipiContatto)
        {
            TipiContatto = tipiContatto;
        }

        public EditPersonModalViewModel()
        {

        }
    }
}