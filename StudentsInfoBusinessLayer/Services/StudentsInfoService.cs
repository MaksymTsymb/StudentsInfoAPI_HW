using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using DataAccesLayer;
using DataAccesLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class StudentsInfoService : IStudentsInfoService
    {
        private readonly IStudentsInfoRepository studentsInfoRepository;
        private readonly IMapper mapper;

        public StudentsInfoService(IStudentsInfoRepository studentsInfoRepository, IMapper mapper)
        {
            this.studentsInfoRepository = studentsInfoRepository;
            this.mapper = mapper;
        }

        public Guid AddStudentsInfo(StudentsInfo studentsInfo)
        {
            var studentsInfoDTO = mapper.Map<StudentsInfoDTO>(studentsInfo);

            return studentsInfoRepository.AddStudentsInfoDTO(studentsInfoDTO);
        }

        public IEnumerable<StudentsInfo> GetAll()
        {
            var studentsInfoDTOs = studentsInfoRepository.GetAll();
            var studentsInfos = studentsInfoDTOs.Select(dto => mapper.Map<StudentsInfo>(dto));

            return studentsInfos;
            
        }

        public StudentsInfo GetById(Guid id)
        {
            var studentsInfoDTO = studentsInfoRepository.GetById(id);
            var studentsInfo = mapper.Map<StudentsInfo>(studentsInfoDTO);

            return studentsInfo;
        }

        public bool RemoveAllStudentsInfo()
        {
            var result = false;
            var studentsInfoDTOIDs = studentsInfoRepository.GetAll().Select(x => x.Id).ToList();

            foreach (var id in studentsInfoDTOIDs)
            {
                RemoveStudentsInfo(id);
            }
                
            if (studentsInfoRepository.GetAll().Count() == 0)
            {
                result = true;
            }

            return result;
        }

        public bool RemoveStudentsInfo(Guid id)
        {
            return studentsInfoRepository.RemoveStudentsInfoDTO(id);
        }

        public bool Update(StudentsInfo studentsInfo)
        {
            var studentsInfoDTO = mapper.Map<StudentsInfoDTO>(studentsInfo);

            return studentsInfoRepository.Update(studentsInfoDTO);
        }
    }
}
