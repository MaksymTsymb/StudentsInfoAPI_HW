using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer;
using BusinessLayer.Interfaces;

namespace WebAppHW2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StudentsInfoController : ControllerBase
    {
        private readonly IStudentsInfoService studentsInfoService;

        public StudentsInfoController(IStudentsInfoService studentsInfoService)
        {
            this.studentsInfoService = studentsInfoService;
        }

        [Authorize(Roles = "Administrator,Student")]
        [HttpPost]
        public Guid Post(StudentsInfo studentsInfo)
        {
            return studentsInfoService.AddStudentsInfo(studentsInfo);
        }

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<StudentsInfo> GetAll()
        {
            return studentsInfoService.GetAll();
        }


        [Authorize(Roles = "Administrator,Student")]
        [HttpGet("{id}")]
        public StudentsInfo GetById(Guid id)
        {
            return studentsInfoService.GetById(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public bool Edit(StudentsInfo studentsInfo)
        {
            return studentsInfoService.Update(studentsInfo);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public bool DeleteById(Guid id)
        {
            return studentsInfoService.RemoveStudentsInfo(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete]
        public bool DeleteAll()
        {
            return studentsInfoService.RemoveAllStudentsInfo();
        }
    }
}
