using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CTC.Phonebook.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CTC.Web.Models.Phonebook.ViewModel
{

    [AutoMapFrom(typeof(ListResultDto<PersonListDto>))]
    public class IndexViewModel : ListResultDto<PersonListDto>
    {
        public string Filter { get; set; }

        public List<SelectListItem> TipiContatto { get; set; }

        public IndexViewModel(List<SelectListItem> tipiContatto)
        {
            TipiContatto = tipiContatto;
        }

        public IndexViewModel()
        {

        }
    }

}