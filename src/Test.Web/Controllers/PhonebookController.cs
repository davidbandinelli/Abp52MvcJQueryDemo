using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Events.Bus.Exceptions;
using Abp.Events.Bus.Handlers;
using Abp.UI;
using Abp.Web.Mvc.Authorization;
using Test.Authorization;
using CTC.Phonebook.Dto;
using CTC.Phonebook.Interfaces;
using CTC.Web.Models.Phonebook.ViewModel;
using Test.Entities.Enums;

namespace Test.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Phonebook)]
    public class PhonebookController : TestControllerBase
    {
        private readonly IPersonAppService _personAppService;

        public PhonebookController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }

        public async Task<ActionResult> Index(GetPeopleInput input)
        {
            var output = _personAppService.GetPeople(input);
            var model = ObjectMapper.Map<IndexViewModel>(output);

            // dropdown
            var listaTipiContatto = Enum.GetValues(typeof(TipiContatto)).Cast<TipiContatto>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();

            model.Filter = input.Filter;
            model.TipiContatto = listaTipiContatto;

            return View(model);
        }

        public async Task<ActionResult> EditPersonModal(int personId)
        {
            var person = _personAppService.GetPersonForEdit(new EntityDto<int>(personId));

            // dropdown
            var listaTipiContatto = Enum.GetValues(typeof(TipiContatto)).Cast<TipiContatto>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();

            var model = new EditPersonModalViewModel
            {
                Person = person,
                TipiContatto = listaTipiContatto
            };
            return View("_EditPersonModal", model);
        }

    }
}