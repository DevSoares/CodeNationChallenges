using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccelerationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AccelerationService _accelerationService;

        public AccelerationController(IMapper mapper, AccelerationService accelerationService)
        {
            _mapper = mapper;
            _accelerationService = accelerationService;
        }

        // GET api/acceleration/n
        [HttpGet("{id}")]
        public ActionResult<AccelerationDTO> Get(int id)
        {
            Acceleration acceleration = _accelerationService.FindById(id);

            AccelerationDTO accelerationDTO = null;

            if (acceleration != null)
                accelerationDTO = _mapper.Map<AccelerationDTO>(acceleration);

            return accelerationDTO;
        }

        // GET api/acceleration/
        [HttpGet("{companyId}")]
        public ActionResult<List<AccelerationDTO>> Get(int? companyId)
        {
            List<Acceleration> accelerationList = new List<Acceleration>();
            List<AccelerationDTO> accelerationDtoList = new List<AccelerationDTO>();

            if (companyId != null)
                accelerationList = _accelerationService.FindByCompanyId((int)companyId).ToList();
            else
                return StatusCode(204);

            if (accelerationList.Count() > 0)
            {
                foreach(Acceleration acceleration in accelerationList)
                {
                    accelerationDtoList.Add(_mapper.Map<AccelerationDTO>(acceleration));
                }
            }

            return accelerationDtoList;
        }

        // POST api/acceleration
        [HttpPost]
        public Acceleration Post([FromBody] AccelerationDTO accelerationDTO)
        {
            Acceleration acceleration = _mapper.Map<Acceleration>(accelerationDTO);
            return _accelerationService.Save(acceleration);
        }
    }
}
