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
    public class CandidateController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CandidateService _candidateService;

        public CandidateController(IMapper mapper, CandidateService candidateService)
        {
            _mapper = mapper;
            _candidateService = candidateService;
        }

        // GET api/candidate/{userId}/{accelerationId}/{companyId}
        [HttpGet("{userId}/{accelerationId}/{companyId}")]
        public ActionResult<CandidateDTO> Get(int userId, int accelerationId, int companyId)
        {
            Candidate candidate = _candidateService.FindById(userId, accelerationId, companyId);

            CandidateDTO candidateDto = null;

            if (candidate != null)
                candidateDto = _mapper.Map<CandidateDTO>(candidate);

            return candidateDto;
        }


    }
}
